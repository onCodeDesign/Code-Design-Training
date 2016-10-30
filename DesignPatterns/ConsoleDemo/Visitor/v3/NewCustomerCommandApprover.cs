using System;

namespace ConsoleDemo.Visitor.v3
{
	class NewCustomerCommandApprover : IVisitor
	{
		private ICrmService crmService;

		public NewCustomerCommandApprover(ICrmService crmService)
		{
			this.crmService = crmService;
		}

		public void VisitCustomerCommand(NewCustomerCommand customerCommand)
		{
			Console.WriteLine($"We have new customer! {customerCommand.Name} welcome!");
		}

		public void VisitSalesOrderCommand(NewSalesOrderCommand salesOrderCommand)
		{
		}

		public void VisitPurchaseOrderCommand(NewPurchaseOrderCommand purchaseOrder)
		{
		}

		public NewCustomerCommandApprover()
		{
		}
	}
}