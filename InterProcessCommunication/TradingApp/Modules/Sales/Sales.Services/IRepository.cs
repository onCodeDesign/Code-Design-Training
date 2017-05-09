using System.Collections.Generic;
using System.Linq;

namespace Sales.Services
{
    interface IRepository
    {
        void Save<T>(T entity);
        void SaveAll<T>(IEnumerable<T> entities);
        IQueryable<T> GetEntities<T>();
    }
}