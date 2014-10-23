using System;
using System.Linq;

namespace LessonsSamples.Lesson6.DI_AndDisposable
{
    interface IRepository : IDisposable
    {
        IQueryable<T> GetEntities<T>();
        IUnitOfWork CreateUnitOfWork();
    }

    interface IUnitOfWork : IRepository
    {
        void SaveChanges();
    }

    class Repository : IRepository
    {
        private Session session;

        public IQueryable<T> GetEntities<T>()
        {
            return Session.Query<T>();
        }

        public void Dispose()
        {
            if (session != null)
                session.Dispose();
        }

        private Session Session
        {
            get
            {
                if (session == null) //this should be thread safe
                    session = new Session();

                return session;
            }
        }

        public IUnitOfWork CreateUnitOfWork()
        {
            throw new NotImplementedException();
        }
    }

    class Session : IDisposable
    {
        public IQueryable<T> Query<T>()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}