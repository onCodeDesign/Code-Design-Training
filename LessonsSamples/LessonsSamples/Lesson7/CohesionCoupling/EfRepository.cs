using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Transactions;

namespace LessonsSamples.Lesson7.CohesionCoupling
{
    public class EfRepository : IRepository, IDisposable
    {
        private DbContext context;

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
                    context = new DbContext("some dummy connection string");
                return context;
            }
        }

        private sealed class EfUnitOfWork : IUnitOfWork
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

            private void Handle(Exception exception)
            {
                //TODO: go  forward to DA exception handler
            }

            private void InterceptSave(List<object> interceptedEntities)
            {
                // Go through all registered interceptors and call the .OnSave method, 
                //   for each of the intercepted entity
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
                        context = new DbContext("some dummy connection string");
                    return context;
                }
            }
        }
    }
}