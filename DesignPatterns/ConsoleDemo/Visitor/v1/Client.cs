using System;
using System.Collections.Generic;

namespace ConsoleDemo.Visitor.v1
{
	public class CommandsManager
	{
		readonly List<object> items = new List<object>();

		public void PrettyPrint()
		{
			foreach (var item in items)
			{
				if (item is NewPurchaseOrderCommand)
				   Print((NewPurchaseOrderCommand)item);
				else if (item is NewSalesOrderCommand)
					Print((NewSalesOrderCommand)item);
				else if (item is NewCustomerCommand)
					Print((NewCustomerCommand)item);
			}
		}

		private void Print(NewPurchaseOrderCommand item)
		{
			Console.WriteLine($"Purchase order request: Product={item.Product} Quatity={item.Quantity}");
        }

		private void Print(NewSalesOrderCommand item)
		{
			Console.WriteLine("Sales order request: ");
			foreach (var line in item.OrderLines)
			{
				Console.WriteLine($"\t Product={line.Product} Quantity={line.Quantity}");
			}
		}

		private void Print(NewCustomerCommand item)
		{
			Console.WriteLine($"New customer request: {item.Name} in business: {item.BusinessDomain}");
		}

		public void ApproveAll()
		{
			foreach (var item in items)
			{

				if (item is NewPurchaseOrderCommand)
					Approve((NewPurchaseOrderCommand)item);
				else if (item is NewSalesOrderCommand)
					Approve((NewSalesOrderCommand)item);
				else if (item is NewCustomerCommand)
					Approve((NewCustomerCommand)item);
			}
		}

		private void Approve(NewCustomerCommand item)
		{
			// Interact w/ the databse and use external services to process a new purchase order request
		}

		private void Approve(NewSalesOrderCommand item)
		{
			// Interact w/ the databse and use external services to process a new purchase order request
		}

		private void Approve(NewPurchaseOrderCommand item)
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