using System;

namespace ConsoleDemo.Visitor.v6
{
    class PurchaseOrderCommandApprover : IVisitor<NewPurchaseOrderCommand>
    {
        private readonly IVisitor visitor;

        public PurchaseOrderCommandApprover()
        {
            visitor = new Visitor(this);
        }

        public void Visit(NewPurchaseOrderCommand purchaseOrder)
        {
            Console.WriteLine($"Purchase of: {purchaseOrder.Product.Name} was approved.");
        }

        public IVisitor AsVisitor()
        {
            return visitor;
        }
    }
}