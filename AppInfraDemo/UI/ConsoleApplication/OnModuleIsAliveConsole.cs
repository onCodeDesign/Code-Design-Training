using System;
using Contracts.Notifications;
using iQuarc.AppBoot;

namespace ConsoleApplication
{
	[Service("Module Is Alive on Console", typeof(IAmAliveSubscriber<IModule>))]
	public class OnModuleIsAliveConsole : IAmAliveSubscriber<IModule>
	{
		public void AmAlive(IModule item)
		{
			Console.WriteLine(item.GetType().Name);
		}
	}
}