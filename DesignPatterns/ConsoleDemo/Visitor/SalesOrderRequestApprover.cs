using System;

namespace ConsoleDemo.Visitor.v3
{
	class SalesOrderRequestApprover : IVisitor
	{
		public void VisitSalesOrderRequest(NewSalesOrderRequest salesOrderRequest)
		{
			Console.WriteLine($"Sales Order from {salesOrderRequest.CustomerCode} was approved.");
		}

		public void VisitCustomerRequest(NewCustomerRequest customerRequest)
		{
		}

		public void VisitPurchaseOrderRequest(NewPurchaseOrderRequest purchaseOrder)
		{
		}
	}
}