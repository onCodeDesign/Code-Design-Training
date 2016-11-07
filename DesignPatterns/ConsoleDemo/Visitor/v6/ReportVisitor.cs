using System;
using System.Text;

namespace ConsoleDemo.Visitor.v6
{
    class ReportVisitor :   IVisitor<NewCustomerCommand>,
                            IVisitor<NewSalesOrderCommand>,
                            IVisitor<NewPurchaseOrderCommand>
    {
        readonly StringBuilder report = new StringBuilder();
        private readonly IVisitor visitor;

        public ReportVisitor()
        {
            visitor = new Visitor(this);
        }

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
                report.AppendLine($"\t - Product={line.Product} Quantity={line.Quantity}");
            }
        }

        public void Visit(NewPurchaseOrderCommand purchaseOrder)
        {
            report.AppendLine($"Purchase order request: Product={purchaseOrder.Product} Quantity={purchaseOrder.Quantity}");
        }

        public IVisitor AsVisitor()
        {
            return visitor;
        }
    }
}