using System;

namespace ConsoleDemo.Visitor.v5
{
	class SalesOrderCommandApprover : IVisitor<NewSalesOrderCommand>
	{
	    public void Visit(NewSalesOrderCommand salesOrderCommand)
		{
			Console.WriteLine($"Sales Order from {salesOrderCommand.CustomerCode} was approved.");
		}
	}
}