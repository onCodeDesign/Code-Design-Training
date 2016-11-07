using System;

namespace ConsoleDemo.Visitor.v3
{
	class PurchaseOrderCommandApprover : IVisitor
	{
		public void VisitPurchaseOrderCommand(NewPurchaseOrderCommand purchaseOrder)
		{
			Console.WriteLine($"Purchase of: {purchaseOrder.Product.Name} was approved.");
		}

		public void VisitCustomerCommand(NewCustomerCommand customerCommand)
		{
		}

		public void VisitSalesOrderCommand(NewSalesOrderCommand salesOrderCommand)
		{
		}
	}
}