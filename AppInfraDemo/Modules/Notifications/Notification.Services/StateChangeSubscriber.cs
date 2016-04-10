using Contracts.Notifications;
using iQuarc.AppBoot;

namespace Notifications
{
    [Service("Default Change Subscriber", typeof (IStateChangeSubscriber<>))]
    class StateChangeSubscriber<T> : IStateChangeSubscriber<T>
    {
        public void NewItem(T item)
        {
            //TODO: write to monitoring dashboard
        }

        public void NotifyDeleted(T item)
        {
            //TODO: write to monitoring dashboard
        }

        public void NotifyChanged(T item)
        {
            //TODO: write to monitoring dashboard
        }
    }
}