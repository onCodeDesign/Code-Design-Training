using System;

namespace ConsoleDemo.Visitor.v5
{
    static class DemoData
    {
        public static IVisitable[] GetItems()
        {
            return new IVisitable[]
            {
                new NewPurchaseOrderCommand(new Product {Name = "iPhone"}, 5),
                new NewPurchaseOrderCommand(new Product {Name = "MacBookPro"}, 7),
                new NewPurchaseOrderCommand(new Product {Name = "MacBookAir"}, 1),

                new NewSalesOrderCommand("Apple", DateTime.Today).AddOrderLine("AwesomeApp v2", 2),
                new NewSalesOrderCommand("Microsoft", DateTime.Today).AddOrderLine("AwesomeApp v1", 1),

                new NewCustomerCommand("Deep Mind", "Computers")
            };
        }
    }
}