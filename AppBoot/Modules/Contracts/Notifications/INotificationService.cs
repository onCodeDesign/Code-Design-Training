namespace Contracts.Notifications
{
    public interface INotificationService
    {
        void NotifyNew<T>(T item);
        void NotifyDeleted<T>(T item);
        void NotifyChanged<T>(T item);
        void NotifyStatusChange<T>(T item, Status newStatus, Status oldStatus);
        void NotifyAlive<T>(T item);
    }
}