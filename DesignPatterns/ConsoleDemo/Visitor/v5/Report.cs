using System;
using System.Text;

namespace ConsoleDemo.Visitor.v4
{
    class Report : 
        IVisitor<NewCustomerCommand>,
        IVisitor<NewSalesOrderCommand>,
        IVisitor<NewPurchaseOrderCommand>
    {
        readonly StringBuilder report = new StringBuilder();

        public void Print()
        {
            Console.WriteLine(report);
        }

        public void Visit(NewCustomerCommand customerCommand)
        {
            report.AppendLine($"New customer request: {customerCommand.Name} in business: {customerCommand.BusinessDomain}");
        }

        public void Visit(NewSalesOrderCommand salesOrderCommand)
        {
            report.AppendLine("Sales order request: ");
            foreach (var line in salesOrderCommand.OrderLines)
            {
                report.AppendLine($"\t Product={line.Product} Quantity={line.Quantity}");
            }
        }

        public void Visit(NewPurchaseOrderCommand purchaseOrder)
        {
            report.AppendLine($"Purchase order request: Product={purchaseOrder.Product} Quatity={purchaseOrder.Quantity}");
        }
    }
}