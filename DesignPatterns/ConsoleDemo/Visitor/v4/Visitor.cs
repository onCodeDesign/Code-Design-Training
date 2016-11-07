namespace ConsoleDemo.Visitor.v4
{
    abstract class Visitor : IVisitor
    {
        public virtual void VisitCustomerCommand(NewCustomerCommand customerCommand)
        {
        }

        public virtual void VisitSalesOrderCommand(NewSalesOrderCommand salesOrderCommand)
        {
        }

        public virtual void VisitPurchaseOrderCommand(NewPurchaseOrderCommand purchaseOrder)
        {
        }
    }
}