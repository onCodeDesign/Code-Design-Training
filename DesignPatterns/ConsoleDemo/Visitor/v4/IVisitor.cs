namespace ConsoleDemo.Visitor.v4
{
	public interface IVisitor
	{
		void VisitCustomerCommand(NewCustomerCommand customerCommand);
		void VisitSalesOrderCommand(NewSalesOrderCommand salesOrderCommand);
		void VisitPurchaseOrderCommand(NewPurchaseOrderCommand purchaseOrder);
	}
}