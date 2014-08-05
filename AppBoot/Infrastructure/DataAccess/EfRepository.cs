using System;
using System.Data.Entity;
using System.Linq;
using System.Transactions;
using DataAccess.DbContexts;
using DataAccess.Exceptions;
using Seido.AppBoot;

namespace DataAccess
{
    [Service(typeof (IRepository))]
    public class EfRepository : IRepository, IDisposable
    {
        private DbContext context;

        private static readonly IRepositoryExceptionHandler[] exceptionHandlers =
        {
            new RepositorySqlExceptionHandler(),
            new RepositoryConcurrencyExceptionHandler(),
            new RepositoryUpdateExceptionHandler(),
            new RepositoryDbEntityValidationExceptionHandler(), 
            new RepositoryDefaultExceptionHandler()
        };

        public IQueryable<T> GetEntities<T>() where T : class
        {
            return Context.Set<T>().AsNoTracking();
        }

        public IUnitOfWork CreateUnitOfWork()
        {
            return new EfUnitOfWork();
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
                    context = new SalesEntities();
                return context;
            }
        }

        private static void Handle(Exception exception)
        {
            foreach (var exceptionHandler in exceptionHandlers)
            {
                exceptionHandler.Handle(exception);
            }
        }

        private class EfUnitOfWork : IUnitOfWork
        {
            private DbContext context;
            private TransactionScope transactionScope;

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
                    context.SaveChanges();

                    if (transactionScope != null)
                        transactionScope.Complete();
                }
                catch (Exception e)
                {
                    Handle(e);
                }
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
                if (transactionScope != null) throw new InvalidOperationException("Cannot begin another transaction scope");

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
                        context = new SalesEntities();
                    return context;
                }
            }
        }
    }
}