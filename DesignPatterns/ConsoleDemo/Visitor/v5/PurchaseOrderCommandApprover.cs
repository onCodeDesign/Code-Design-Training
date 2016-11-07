using System;

namespace ConsoleDemo.Visitor.v5
{
    class PurchaseOrderCommandApprover : IVisitor<NewPurchaseOrderCommand>
    {
        public void Visit(NewPurchaseOrderCommand purchaseOrder)
        {
            Console.WriteLine($"Purchase of: {purchaseOrder.Product.Name} was approved.");
        }
    }
}