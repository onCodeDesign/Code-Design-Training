using System;

namespace ConsoleDemo.Visitor.v3
{
	class SalesOrderCommandApprover : IVisitor
	{
		public void VisitSalesOrderCommand(NewSalesOrderCommand salesOrderCommand)
		{
			Console.WriteLine($"Sales Order from {salesOrderCommand.CustomerCode} was approved.");
		}

		public void VisitCustomerCommand(NewCustomerCommand customerCommand)
		{
		}

		public void VisitPurchaseOrderCommand(NewPurchaseOrderCommand purchaseOrder)
		{
		}
	}
}