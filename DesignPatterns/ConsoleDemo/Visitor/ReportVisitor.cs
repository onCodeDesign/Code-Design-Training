using System;
using System.Text;

namespace ConsoleDemo.Visitor.v3
{
	class ReportVisitor : IVisitor
	{
		readonly StringBuilder report = new StringBuilder();

		public void Print()
		{
			Console.WriteLine(report);
		}

		public void VisitCustomerRequest(NewCustomerRequest customerRequest)
		{
			report.AppendLine($"New customer request: {customerRequest.Name} in business: {customerRequest.BusinessDomain}");
		}

		public void VisitSalesOrderRequest(NewSalesOrderRequest salesOrderRequest)
		{
			report.AppendLine("Sales order request: ");
			foreach (var line in salesOrderRequest.OrderLines)
			{
				report.AppendLine($"\t Product={line.Product} Quantity={line.Quantity}");
			}
		}

		public void VisitPurchaseOrderRequest(NewPurchaseOrderRequest purchaseOrder)
		{
			report.AppendLine($"Purchase order request: Product={purchaseOrder.Product} Quatity={purchaseOrder.Quantity}");
		}
	}
}