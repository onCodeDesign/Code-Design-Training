using System;
using System.Linq;

namespace LessonsSamples.Lesson7.CohesionCoupling
{
    public interface IRepository
    {
        IQueryable<TDbEntity> GetEntities<TDbEntity>() where TDbEntity : class;
        IUnitOfWork CreateUnitOfWork();
    }

    public interface IUnitOfWork : IRepository, IDisposable
    {
        void SaveChanges();

        void Add<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;
    }
}