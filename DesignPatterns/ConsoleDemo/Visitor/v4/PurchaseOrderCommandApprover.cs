using System;

namespace ConsoleDemo.Visitor.v4
{
class PurchaseOrderCommandApprover : Visitor
{
	public override void VisitPurchaseOrderCommand(NewPurchaseOrderCommand purchaseOrder)
	{
		Console.WriteLine($"Purchase of: {purchaseOrder.Product.Name} was approved.");
	}
}
}