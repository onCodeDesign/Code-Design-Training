namespace DataAccess
{
    /// <summary>
    ///     A template to build global entity interceptors.
    ///     Concrete implementation of this should be registered as IEntityInterceptor and they will be applied to all entities
    ///     of any type which inherits T
    /// </summary>
    /// <typeparam name="T">
    ///     The type which should be inherited / implemented by the entity that is going to be intercepted by
    ///     this interceptor
    /// </typeparam>
    public abstract class GlobalEntityInterceptor<T> : IEntityInterceptor
        where T : class
    {
        public abstract void OnLoad(IEntityEntryFacade<T> entry, IRepository repository);
        public abstract void OnSave(IEntityEntryFacade<T> entry, IRepository repository);
        public abstract void OnEntityRemoved(IEntityEntryFacade<T> entry, IRepository repository);

        void IEntityInterceptor.OnLoad(IEntityEntryFacade entry, IRepository repository)
        {
            if (entry.Entity is T)
                this.OnLoad(entry.Convert<T>(), repository);
        }

        void IEntityInterceptor.OnSave(IEntityEntryFacade entry, IRepository repository)
        {
            if (entry.Entity is T)
                this.OnSave(entry.Convert<T>(), repository);
        }

        void IEntityInterceptor.OnEntityRemoved(IEntityEntryFacade entry, IRepository repository)
        {
            if (entry.Entity is T)
                this.OnEntityRemoved(entry.Convert<T>(), repository);
        }
    }
}