using System;
using System.Diagnostics;
using System.Linq;

namespace ConsoleDemo.Visitor.v3
{
	public static class VisitorDemo3
	{
		public static void Run()
		{
			var client = new CommandsManager();

			Console.WriteLine();
			Console.WriteLine("PrettyPrint");
			client.PrettyPrint();

			Console.WriteLine();
			Console.WriteLine("ApproveAll");
			client.ApproveAll();
		}

		
	}
}