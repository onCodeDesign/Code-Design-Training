using Contracts.Notifications;
using Seido.AppBoot;

namespace Notifications
{
    [Service("Default Change Subscriber", typeof (IStateChangeSubscriber<>))]
    class StateChangeSubscriber<T> : IStateChangeSubscriber<T>
    {
        public void NewItem(T item)
        {
            //TODO: write to monitoring dashboard
        }

        public void NotifyDeleted<T1>(T1 item)
        {
            //TODO: write to monitoring dashboard
        }

        public void NotifyChanged<T1>(T1 item)
        {
            //TODO: write to monitoring dashboard
        }
    }
}