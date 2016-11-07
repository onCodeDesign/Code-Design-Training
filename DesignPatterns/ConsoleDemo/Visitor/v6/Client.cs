using System.Collections.Generic;

namespace ConsoleDemo.Visitor.v6
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
        ReportVisitor reportVisitor = new ReportVisitor();

        foreach (var item in items)
        {
            item.Accept(reportVisitor.AsVisitor());
        }

        reportVisitor.Print();
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
                new NewCustomerCommandApporver().AsVisitor(), 
                new PurchaseOrderCommandApprover().AsVisitor(), 
                new SalesOrderCommandApprover().AsVisitor(), 
            };
        }
    }
}