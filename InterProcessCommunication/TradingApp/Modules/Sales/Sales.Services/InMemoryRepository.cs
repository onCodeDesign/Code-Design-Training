using System;
using System.Collections.Generic;
using System.Linq;
using iQuarc.AppBoot;
using iQuarc.SystemEx;

namespace Sales.Services
{
    [Service(typeof(IRepository))]
    class InMemoryRepository : IRepository
    {
        static readonly Dictionary<Type, List<object>> storage = new Dictionary<Type, List<object>>();

        public void Save<T>(T entity)
        {
            var entityList = GetOrCreateEntityList<T>();
            entityList.Add(entity);
        }

        private static List<object> GetOrCreateEntityList<T>()
        {
            Type entityType = typeof(T);
            List<object> entityList;
            if (!storage.TryGetValue(entityType, out entityList))
            {
                entityList = new List<object>();
                storage.Add(entityType, entityList);
            }
            return entityList;
        }

        public void SaveAll<T>(IEnumerable<T> entities)
        {
            var entityList = GetOrCreateEntityList<T>();
            entities.ForEach(e=>entityList.Add(e));
        }

        public IQueryable<T> GetEntities<T>()
        {
            List<object> entityList;
            if (storage.TryGetValue(typeof(T), out entityList))
                return entityList.Cast<T>().AsQueryable();

            return Enumerable.Empty<T>().AsQueryable();
        }
    }
}