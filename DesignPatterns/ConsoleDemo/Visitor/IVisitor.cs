namespace ConsoleDemo.Visitor.v3
{
	public interface IVisitor
	{
		void VisitCustomerCommand(NewCustomerCommand customerCommand);
		void VisitSalesOrderCommand(NewSalesOrderCommand salesOrderCommand);
		void VisitPurchaseOrderCommand(NewPurchaseOrderCommand purchaseOrder);
	}
}