using System;
using System.Collections.Generic;

namespace ConsoleDemo.Visitor.v5
{
    public class NewPurchaseOrderCommand : IVisitable
    {
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public NewPurchaseOrderCommand(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public Product Product { get; }

        public int Quantity { get; }
    }

    public class NewSalesOrderCommand : IVisitable
    {
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        private readonly List<OrderLine> orderLines;

        public NewSalesOrderCommand(string customerCode, DateTime date)
        {
            CustomerCode = customerCode;
            Date = date;
            orderLines = new List<OrderLine>();
        }

        public IEnumerable<OrderLine> OrderLines => orderLines;

        public string CustomerCode { get; set; }

        public DateTime Date { get; set; }

        public NewSalesOrderCommand AddOrderLine(string product, int quantity)
        {
            orderLines.Add(new OrderLine
            {
                Product = new Product {Name = product},
                Quantity = quantity
            });

            return this;
        }
    }

    public class NewCustomerCommand : IVisitable
    {
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public NewCustomerCommand(string name, string businessDomain)
        {
            Name = name;
            BusinessDomain = businessDomain;
        }

        public string Name { get; set; }

        public string BusinessDomain { get; set; }
    }
}