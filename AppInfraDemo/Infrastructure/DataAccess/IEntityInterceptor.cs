using System;

namespace DataAccess
{
    public interface IEntityInterceptor
    {
        void OnLoad(IEntityEntryFacade entry, IRepository repository);
        void OnSave(IEntityEntryFacade entity, IRepository repository);
        void OnEntityRemoved(IEntityEntryFacade entity, IRepository repository);
    }

    public interface IEntityInterceptor<T> : IEntityInterceptor
        where T : class
    {
        void OnLoad(IEntityEntryFacade<T> entry, IRepository repository);
        void OnSave(IEntityEntryFacade<T> entry, IRepository repository);
        void OnEntityRemoved(IEntityEntryFacade<T> entity, IRepository repository);
    }
}