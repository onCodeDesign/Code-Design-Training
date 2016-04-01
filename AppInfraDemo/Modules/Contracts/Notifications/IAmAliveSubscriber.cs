namespace Contracts.Notifications
{
	public interface IAmAliveSubscriber<T>
	{
		void AmAlive(T item);
	}
}