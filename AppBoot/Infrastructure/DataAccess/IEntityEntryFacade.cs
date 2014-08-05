using System;

namespace DataAccess
{
    public interface IEntityEntryFacade
    {
        object Entity { get; }
        EntityEntryStates State { get; }
        object GetOriginalValue(string propertyName);
        IEntityEntryFacade<T> Convert<T>() where T : class;
        void SetOriginalValue(string propertyName, object value);

    }

    public interface IEntityEntryFacade<T>
        where T : class
    {
        T Entity { get; }
        EntityEntryStates State { get; }
        object GetOriginalValue(string propertyName);
        void SetOriginalValue(string propertyName, object value);
    }

    [Flags]
    public enum EntityEntryStates
    {
        Detached = 1,
        Unchanged = 2,
        Added = 4,
        Deleted = 8,
        Modified = 16,
    }
}