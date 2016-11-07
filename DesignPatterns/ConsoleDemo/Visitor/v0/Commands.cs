using System;
using System.Collections.Generic;

namespace ConsoleDemo.Visitor.v0
{
    class NewCustomerCommand
    {
        public string Name { get; set; }

        public string BusinessDomain { get; set; }
    }

    class NewPurchaseOrderCommand
    {
        public NewPurchaseOrderCommand(Product product, int i)
        {
            Product = product;
        }

        public Product Product { get; }

        public int Quantity { get; }
    }

    class NewSalesOrderCommand
    {
        public IEnumerable<OrderLine> OrderLines { get; }

        public string CustomerCode { get; set; }

        public DateTime Date { get; set; }
    }
}