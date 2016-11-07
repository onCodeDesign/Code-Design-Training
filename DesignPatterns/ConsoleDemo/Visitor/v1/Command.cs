using System;
using System.Collections.Generic;

namespace ConsoleDemo.Visitor.v1
{

	class NewPurchaseOrderCommand
	{
		public NewPurchaseOrderCommand(Product product)
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

	class NewCustomerCommand
	{
		public string Name { get; set; }

		public string BusinessDomain { get; set; }
	}
}
