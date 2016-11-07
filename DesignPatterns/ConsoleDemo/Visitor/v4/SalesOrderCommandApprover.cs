using System;

namespace ConsoleDemo.Visitor.v4
{
	class SalesOrderCommandApprover : Visitor
	{
		public override void VisitSalesOrderCommand(NewSalesOrderCommand salesOrderCommand)
		{
			Console.WriteLine($"Sales Order from {salesOrderCommand.CustomerCode} was approved.");
		}
	}
}