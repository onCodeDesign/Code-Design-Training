using System.Data.Entity.Infrastructure;
using System.Linq;

namespace DataAccess
{
    sealed internal class EntityEntry : IEntityEntryFacade
    {
        private readonly DbEntityEntry entry;

        public EntityEntry(DbEntityEntry entry)
        {
            this.entry = entry;
        }

        public object Entity
        {
            get { return this.entry.Entity; }
        }

        public EntityEntryStates State
        {
            get { return (EntityEntryStates)entry.State; }
        }

        public object GetOriginalValue(string propertyName)
        {
            return entry.OriginalValues[propertyName];
        }

        public IEntityEntryFacade<T> Convert<T>() where T : class
        {
            return new EntityEntry<T>(entry.Cast<T>());
        }

        public void SetOriginalValue(string propertyName, object value)
        {
            if (entry.OriginalValues.PropertyNames.Contains(propertyName))
                entry.OriginalValues[propertyName] = value;
        }
    }

    sealed internal class EntityEntry<T> : IEntityEntryFacade<T>
        where T : class
    {
        private readonly DbEntityEntry<T> entry;

        public EntityEntry(DbEntityEntry<T> entry)
        {
            this.entry = entry;
        }

        public T Entity
        {
            get { return entry.Entity; }
        }

        public EntityEntryStates State
        {
            get { return (EntityEntryStates)entry.State; }
        }

        public object GetOriginalValue(string propertyName)
        {
            return entry.OriginalValues[propertyName];
        }

        public void SetOriginalValue(string propertyName, object value)
        {
            if (entry.OriginalValues.PropertyNames.Contains(propertyName))
                entry.OriginalValues[propertyName] = value;
        }
    }
}