using System;

namespace ConsoleDemo.Visitor.v5
{
	public static class VisitorDemo5
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