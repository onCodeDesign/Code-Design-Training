using Contracts.Notifications;
using iQuarc.AppBoot;

namespace Notifications
{
	[Service(typeof(IAmAliveSubscriber<>))]
	class AmAliveSubscriber<T> : IAmAliveSubscriber<T>
	{
		private readonly IAmAliveSubscriber<T>[] subscribers;

		public AmAliveSubscriber(IAmAliveSubscriber<T>[] subscribers)
		{
			this.subscribers = subscribers;
		}

		public void AmAlive(T item)
		{
			foreach (var subscriber in subscribers)
			{
				subscriber.AmAlive(item);
			}
		}
	}
}