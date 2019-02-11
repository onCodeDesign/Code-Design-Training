using Contracts.Notifications;
using iQuarc.AppBoot;
using iQuarc.SystemEx;

namespace Notifications
{
    [Service(typeof(IAmAliveSubscriber<>))]
    class CompositeAmAliveSubscriber<T> : IAmAliveSubscriber<T>
    {
        private readonly IAmAliveSubscriber<T>[] subscribers;

        public CompositeAmAliveSubscriber(IAmAliveSubscriber<T>[] subscribers)
        {
            this.subscribers = subscribers;
        }

        public void AmAlive(T item)
        {
            subscribers.ForEach(s => s.AmAlive(item));
        }
    }
}