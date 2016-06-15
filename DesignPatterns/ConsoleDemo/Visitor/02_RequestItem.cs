using System;
using System.Collections.Generic;

namespace ConsoleDemo.Visitor.v2
{

	interface IRequestProcessor
	{
		void Approve();

		void PrettyPrint();
	}

	class NewPurchaseOrderRequest : IRequestProcessor
	{
		public NewPurchaseOrderRequest(Product product)
		{
			Product = product;
		}

		public void Approve()
		{
			// Interact w/ the databse and use external services to process a new purchase order request
		}

		public void PrettyPrint()
		{
			Console.WriteLine($"Purchase order request: Product={Product} Quatity={Quantity}");
		}

		public Product Product { get; }

		public int Quantity { get;  }
	}

	class NewSalesOrderRequest : IRequestProcessor
	{
		public void Approve()
		{
			// Interact w/ the databse and use external services to process a new sales order request
		}

		public void PrettyPrint()
		{
			Console.WriteLine("Sales order request: ");
			foreach (var line in OrderLines)
			{
				Console.WriteLine($"\t Product={line.Product} Quantity={line.Quantity}");
			}
		}

		public IEnumerable<OrderLine> OrderLines { get; }

		public string CustomerCode { get; set; }

		public DateTime Date { get; set; }
	}

	class NewCustomerRequest : IRequestProcessor
	{
		public void Approve()
		{
			// Interact w/ the databse and use external services to process a new customer
		}

		public void PrettyPrint()
		{
			Console.WriteLine($"New customer request: {Name} in business: {BusinessDomain}");
		}

		public string Name { get; set; }

		public string BusinessDomain { get; set; }
	}
}
