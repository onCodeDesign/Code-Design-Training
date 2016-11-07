using System;

namespace ConsoleDemo.Visitor.v6
{
	public static class VisitorDemo6
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