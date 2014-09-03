namespace DataAccess
{
    public abstract class EntityInterceptor<TEntity> : IEntityInterceptor<TEntity>
        where TEntity : class
    {
        public virtual void OnLoad(IEntityEntryFacade<TEntity> entry, IRepository repository)
        {
        }

        public virtual void OnSave(IEntityEntryFacade<TEntity> entry, IRepository repository)
        {
        }

        public virtual void OnEntityRemoved(IEntityEntryFacade<TEntity> entry, IRepository repository)
        {
        }

        public void OnLoad(IEntityEntryFacade entry, IRepository repository)
        {
            this.OnLoad(entry.Convert<TEntity>(), repository);
        }

        public void OnSave(IEntityEntryFacade entity, IRepository repository)
        {
            this.OnSave(entity.Convert<TEntity>(), repository);
        }

        public void OnEntityRemoved(IEntityEntryFacade entity, IRepository repository)
        {
            this.OnEntityRemoved(entity.Convert<TEntity>(), repository);
        }
    }
}