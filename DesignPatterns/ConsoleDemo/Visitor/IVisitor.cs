using System;

namespace ConsoleDemo.Visitor.v3
{
	public interface IVisitor
	{
		void VisitCustomerRequest(NewCustomerRequest customerRequest);
		void VisitSalesOrderRequest(NewSalesOrderRequest salesOrderRequest);
		void VisitPurchaseOrderRequest(NewPurchaseOrderRequest purchaseOrder);
	}

	class NewCustomerRequestApprover : IVisitor
	{
		public void VisitCustomerRequest(NewCustomerRequest customerRequest)
		{
			Console.WriteLine($"We have new customer! {customerRequest.Name} wellcome!");
		}

		public void VisitSalesOrderRequest(NewSalesOrderRequest salesOrderRequest)
		{
		}

		public void VisitPurchaseOrderRequest(NewPurchaseOrderRequest purchaseOrder)
		{
		}
	}
}