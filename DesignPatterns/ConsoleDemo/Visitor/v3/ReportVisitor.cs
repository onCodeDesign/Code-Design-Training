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

		public void VisitCustomerCommand(NewCustomerCommand customerCommand)
		{
			report.AppendLine($"New customer request: {customerCommand.Name} in business: {customerCommand.BusinessDomain}");
		}

		public void VisitSalesOrderCommand(NewSalesOrderCommand salesOrderCommand)
		{
			report.AppendLine("Sales order request: ");
			foreach (var line in salesOrderCommand.OrderLines)
			{
				report.AppendLine($"\t Product={line.Product} Quantity={line.Quantity}");
			}
		}

		public void VisitPurchaseOrderCommand(NewPurchaseOrderCommand purchaseOrder)
		{
			report.AppendLine($"Purchase order request: Product={purchaseOrder.Product} Quatity={purchaseOrder.Quantity}");
		}
	}
}