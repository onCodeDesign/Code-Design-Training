using System;
using System.Collections.Generic;

namespace ConsoleDemo.Visitor.v3
{
	public class NewPurchaseOrderRequest : IVisitable
	{
		public NewPurchaseOrderRequest(Product product, int quantity)
		{
			Product = product;
			Quantity = quantity;
		}

		public Product Product { get; }

		public int Quantity { get;  }
		public void Accept(IVisitor visitor)
		{
			visitor.VisitPurchaseOrderRequest(this);
		}
	}

	public class NewSalesOrderRequest : IVisitable
	{
		private readonly List<OrderLine> orderLines;

		public NewSalesOrderRequest(string customerCode, DateTime date)
		{
			CustomerCode = customerCode;
			Date = date;
			orderLines = new List<OrderLine>();
		}

		public IEnumerable<OrderLine> OrderLines => orderLines;

		public string CustomerCode { get; set; }

		public DateTime Date { get; set; }
		public void Accept(IVisitor visitor)
		{
			visitor.VisitSalesOrderRequest(this);
		}

		public NewSalesOrderRequest AddOrderLine(string product, int quantity )
		{
			orderLines.Add(new OrderLine
			{
				Product = new Product { Name = product},
				Quantity = quantity
			});

			return this;
		}
	}

	public class NewCustomerRequest : IVisitable
	{
		public NewCustomerRequest(string name, string businessDomain)
		{
			Name = name;
			BusinessDomain = businessDomain;
		}

		public string Name { get; set; }

		public string BusinessDomain { get; set; }
		public void Accept(IVisitor visitor)
		{
			visitor.VisitCustomerRequest(this);
		}
	}
}
