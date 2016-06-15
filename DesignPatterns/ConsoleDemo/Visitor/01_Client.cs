using System;
using System.Collections.Generic;

namespace ConsoleDemo.Visitor.v1
{
	public class Client1
	{
		readonly List<object> items = new List<object>();

		public void PrettyPrint()
		{
			foreach (var item in items)
			{
				if (item is NewPurchaseOrderRequest)
				   Print((NewPurchaseOrderRequest)item);
				else if (item is NewSalesOrderRequest)
					Print((NewSalesOrderRequest)item);
				else if (item is NewCustomerRequest)
					Print((NewCustomerRequest)item);
			}
		}

		private void Print(NewPurchaseOrderRequest item)
		{
			Console.WriteLine($"Purchase order request: Product={item.Product} Quatity={item.Quantity}");
        }

		private void Print(NewSalesOrderRequest item)
		{
			Console.WriteLine("Sales order request: ");
			foreach (var line in item.OrderLines)
			{
				Console.WriteLine($"\t Product={line.Product} Quantity={line.Quantity}");
			}
		}

		private void Print(NewCustomerRequest item)
		{
			Console.WriteLine($"New customer request: {item.Name} in business: {item.BusinessDomain}");
		}

		public void ApproveAll()
		{
			foreach (var item in items)
			{

				if (item is NewPurchaseOrderRequest)
					Approve((NewPurchaseOrderRequest)item);
				else if (item is NewSalesOrderRequest)
					Approve((NewSalesOrderRequest)item);
				else if (item is NewCustomerRequest)
					Approve((NewCustomerRequest)item);
			}
		}

		private void Approve(NewCustomerRequest item)
		{
			// Interact w/ the databse and use external services to process a new purchase order request
		}

		private void Approve(NewSalesOrderRequest item)
		{
			// Interact w/ the databse and use external services to process a new purchase order request
		}

		private void Approve(NewPurchaseOrderRequest item)
		{
			// Interact w/ the databse and use external services to process a new purchase order request
		}

		public void Save()
		{
			// This might mix DA concerns w/ UI concerns
			throw new NotImplementedException();
		}
	}
}