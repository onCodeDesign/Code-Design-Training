using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Transactions;
using DataAccess.Exceptions.Handlers;
using iQuarc.AppBoot;

namespace DataAccess
{
	class ErrorHandlingRepository : IRepository
	{
		private IRepository repositoryImplementation;
		private IExceptionHandler handler;

		public ErrorHandlingRepository(IRepository repositoryImplementation, IExceptionHandler handler)
		{
			this.repositoryImplementation = repositoryImplementation;
			this.handler = handler;
		}

		public IQueryable<TDbEntity> GetEntities<TDbEntity>() where TDbEntity : class
		{
			try
			{
				return repositoryImplementation.GetEntities<TDbEntity>();
			}
			catch (Exception e)
			{
				handler.Handle(e);
			}

			return null;
		}

		public IUnitOfWork CreateUnitOfWork()
		{
			return repositoryImplementation.CreateUnitOfWork();
		}
	}


	[Service(typeof (IRepository))]
	internal class EfRepository : IRepository, IDisposable
	{
		private readonly IDbContextFactory contextFactory;
		private readonly IInterceptorsResolver interceptorsResolver;
		private DbContext context;
		private readonly IEnumerable<IEntityInterceptor> globalInterceptors;

		public EfRepository(IDbContextFactory contextFactory, IInterceptorsResolver interceptorsResolver)
		{
			this.contextFactory = contextFactory;
			this.interceptorsResolver = interceptorsResolver;
			this.globalInterceptors = interceptorsResolver.GetGlobalInterceptors();
		}

		private static readonly IExceptionHandler exceptionHandlers = new ExceptionHandler();

		public IQueryable<T> GetEntities<T>() where T : class
		{
			return Context.Set<T>().AsNoTracking();
		}

		public IUnitOfWork CreateUnitOfWork()
		{
			return new EfUnitOfWork(contextFactory, interceptorsResolver);
		}

		public void Dispose()
		{
			if (context != null)
				context.Dispose();
		}

		private DbContext Context
		{
			get
			{
				if (context == null)
					context = contextFactory.CreateContext();
				return context;
			}
		}


		private void OnEntityLoaded(object sender, ObjectMaterializedEventArgs e)
		{
			InterceptLoad(globalInterceptors, e.Entity);

			Type entityType = ObjectContext.GetObjectType(e.Entity.GetType());
			IEnumerable<IEntityInterceptor> entityInterceptors = interceptorsResolver.GetEntityInterceptors(entityType);
			InterceptLoad(entityInterceptors, e.Entity);
		}

		private void InterceptLoad(IEnumerable<IEntityInterceptor> interceptors, object entity)
		{
			foreach (var interceptor in interceptors)
			{
				DbEntityEntry dbEntry = Context.Entry(entity);
				EntityEntry entry = new EntityEntry(dbEntry);
				interceptor.OnLoad(entry, this);
			}
		}

		private static void Handle(Exception exception)
		{
			exceptionHandlers.Handle(exception);
		}

		private sealed class EfUnitOfWork : IUnitOfWork
		{
			private DbContext context;
			private TransactionScope transactionScope;

			private readonly IDbContextFactory contextFactory;
			private readonly IInterceptorsResolver interceptorsResolver;
			private readonly IEnumerable<IEntityInterceptor> globalInterceptors;

			public EfUnitOfWork(IDbContextFactory contextFactory, IInterceptorsResolver interceptorsResolver)
			{
				this.contextFactory = contextFactory;
				this.interceptorsResolver = interceptorsResolver;
				this.globalInterceptors = interceptorsResolver.GetGlobalInterceptors();
			}


			public IQueryable<T> GetEntities<T>() where T : class
			{
				return Context.Set<T>();
			}

			public IUnitOfWork CreateUnitOfWork()
			{
				return this;
			}

			public void SaveChanges()
			{
				try
				{
					InterceptSave(new List<object>());

					context.SaveChanges();

					if (transactionScope != null)
						transactionScope.Complete();
				}
				catch (Exception e)
				{
					Handle(e);
				}
			}

			private void InterceptSave(List<object> interceptedEntities)
			{
				IEnumerable<object> modifiedEntities = GetInterceptorModifiedEntities(context).Select(e => e.Entity).ToList();

				if (modifiedEntities.All(interceptedEntities.Contains))
					return;

				foreach (object entity in modifiedEntities.Where(e => !interceptedEntities.Contains(e)))
				{
					InterceptSave(this.globalInterceptors, entity);

					Type entityType = ObjectContext.GetObjectType(entity.GetType());
					IEnumerable<IEntityInterceptor> interceptors = interceptorsResolver.GetEntityInterceptors(entityType);

					this.InterceptSave(interceptors, entity);
					interceptedEntities.AddIfNotExists(entity);
				}

				InterceptSave(interceptedEntities);
			}

			private void InterceptSave(IEnumerable<IEntityInterceptor> interceptors, object entity)
			{
				foreach (var interceptor in interceptors)
				{
					DbEntityEntry dbEntry = Context.Entry(entity);
					EntityEntry entry = new EntityEntry(dbEntry);

					interceptor.OnSave(entry, this);
				}
			}

			private static IEnumerable<DbEntityEntry> GetInterceptorModifiedEntities(DbContext context)
			{
				context.ChangeTracker.DetectChanges();
				var modifiedEntities = context.ChangeTracker.Entries()
					.Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

				return modifiedEntities;
			}

			public void Add<T>(T entity) where T : class
			{
				Context.Set<T>().Add(entity);
			}

			public void Delete<T>(T entity) where T : class
			{
				Context.Set<T>().Remove(entity);
			}

			public void BeginTransactionScope(SimplifiedIsolationLevel isolationLevel)
			{
				if (transactionScope != null)
					throw new InvalidOperationException("Cannot begin another transaction scope");

				transactionScope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions {IsolationLevel = (IsolationLevel) isolationLevel});
			}

			public void Dispose()
			{
				if (transactionScope != null)
					transactionScope.Dispose();

				if (context != null)
					context.Dispose();
			}

			private DbContext Context
			{
				get
				{
					if (context == null)
						context = contextFactory.CreateContext();
					return context;
				}
			}
		}
	}
}