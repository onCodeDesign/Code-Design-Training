using System.Collections.Generic;

namespace ConsoleDemo.Visitor.v5
{
    public class CommandsManager
    {
        private readonly List<IVisitable> items = new List<IVisitable>();

        public CommandsManager()
        {
            this.items.AddRange(DemoData.GetItems());
        }

        public void PrettyPrint()
        {
            Report report = new Report();
            IVisitor reportVisitor = new Visitor(report);

            foreach (var item in items)
            {
                item.Accept(reportVisitor);
            }

            report.Print();
        }

        public void ApproveAll()
        {
            IVisitor[] visitors = GetApproveVisitors();
            foreach (var item in items)
            {
                foreach (var visitor in visitors)
                {
                    item.Accept(visitor);
                }
            }
        }

        private IVisitor[] GetApproveVisitors()
        {
            return new IVisitor[]
            {
                new Visitor(new NewCustomerCommandApporver()), 
                new Visitor(new PurchaseOrderCommandApprover()), 
                new Visitor(new SalesOrderCommandApprover()), 
            };
        }
    }
}