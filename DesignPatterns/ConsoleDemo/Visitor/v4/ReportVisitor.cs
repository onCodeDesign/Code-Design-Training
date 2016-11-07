using System;
using System.Text;

namespace ConsoleDemo.Visitor.v4
{
	class ReportVisitor : Visitor
	{
		readonly StringBuilder report = new StringBuilder();

		public void Print()
		{
			Console.WriteLine(report);
		}

		public override void VisitCustomerCommand(NewCustomerCommand customerCommand)
		{
			report.AppendLine($"New customer request: {customerCommand.Name} in business: {customerCommand.BusinessDomain}");
		}

		public override void VisitSalesOrderCommand(NewSalesOrderCommand salesOrderCommand)
		{
			report.AppendLine("Sales order request: ");
			foreach (var line in salesOrderCommand.OrderLines)
			{
				report.AppendLine($"\t Product={line.Product} Quantity={line.Quantity}");
			}
		}

		public override void VisitPurchaseOrderCommand(NewPurchaseOrderCommand purchaseOrder)
		{
			report.AppendLine($"Purchase order request: Product={purchaseOrder.Product} Quatity={purchaseOrder.Quantity}");
		}
	}
}