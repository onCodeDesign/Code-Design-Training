using System;

namespace ConsoleDemo.Visitor.v3
{
	class PurchaseOrderRequestApprover : IVisitor
	{
		public void VisitPurchaseOrderRequest(NewPurchaseOrderRequest purchaseOrder)
		{
			Console.WriteLine($"Purchase of: {purchaseOrder.Product.Name} was approved.");
		}

		public void VisitCustomerRequest(NewCustomerRequest customerRequest)
		{
		}

		public void VisitSalesOrderRequest(NewSalesOrderRequest salesOrderRequest)
		{
		}
	}
}