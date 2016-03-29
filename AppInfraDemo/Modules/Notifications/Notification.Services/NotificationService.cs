using System.Data;
using Contracts.Notifications;
using iQuarc.AppBoot;
using Microsoft.Practices.ServiceLocation;
using UiContracts;

namespace Notifications
{
    [Service(typeof (INotificationService), Lifetime.Application)]
    public class NotificationService : INotificationService
    {
        private readonly IServiceLocator serviceLocator;
	    private readonly IStatusBar statusBar;

	    public NotificationService(IServiceLocator serviceLocator, IStatusBar statusBar)
	    {
		    this.serviceLocator = serviceLocator;
		    this.statusBar = statusBar;
	    }

	    public void NotifyNew<T>(T item)
        {
            var subscribers = serviceLocator.GetAllInstances<IStateChangeSubscriber<T>>();
            foreach (var subscriber in subscribers)
            {
                subscriber.NewItem(item);
            }
        }

        public void NotifyDeleted<T>(T item)
        {
            throw new System.NotImplementedException();
        }

        public void NotifyChanged<T>(T item)
        {
            throw new System.NotImplementedException();
        }

        public void NotifyStatusChange<T>(T item, Status newStatus, Status oldStatus)
        {
            throw new System.NotImplementedException();
        }

        public void NotifyAlive<T>(T item)
        {
            statusBar.WriteNewMessage($"Is alive: {item}");
        }
    }
}