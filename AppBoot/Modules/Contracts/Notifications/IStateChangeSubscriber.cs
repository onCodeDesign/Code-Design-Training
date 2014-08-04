namespace Contracts.Notifications
{
    public interface IStateChangeSubscriber<T>
    {
        void NewItem(T item);
        void NotifyDeleted<T>(T item);
        void NotifyChanged<T>(T item);
    }
}