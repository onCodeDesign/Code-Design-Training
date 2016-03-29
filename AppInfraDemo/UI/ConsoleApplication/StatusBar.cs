using System;
using iQuarc.AppBoot;
using UiContracts;

namespace ConsoleApplication
{
	[Service(typeof(IStatusBar), Lifetime.Application)]
	public class StatusBar : IStatusBar
	{
		public void WriteNewMessage(string message)
		{
			Console.WriteLine(message);
		}
	}
}