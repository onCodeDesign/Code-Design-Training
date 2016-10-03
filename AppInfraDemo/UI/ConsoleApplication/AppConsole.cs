using System;
using Contracts;
using iQuarc.AppBoot;
using iQuarc.SystemEx;

namespace ConsoleApplication
{
	[Service(typeof(IConsole), Lifetime.Application)]
	class AppConsole : IConsole
	{
		public string AskInput(string message)
		{
			Console.WriteLine();
			Console.WriteLine(message);

			return Console.ReadLine();
		}

		public void WriteEntity<T>(T salesOrderInfo)
		{
			Console.WriteLine();
			Console.WriteLine($"--------------- {typeof(T).Name} ----------------");
			var properties = ReflectionExtensions.GetEditableSimpleProperties(salesOrderInfo);
			foreach (var propertyInfo in properties)
			{
				Console.Write($"{propertyInfo.Name}: ");
				Console.WriteLine(propertyInfo.GetValue(salesOrderInfo));
			}

			Console.WriteLine("-----------------------------------------------------");
		}

		public void WriteLine(string line)
		{
			Console.WriteLine(line);
		}
	}
}