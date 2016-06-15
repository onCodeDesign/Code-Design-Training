using System;

namespace ConsoleDemo.Visitor.v3
{
	static class DemoData
	{
		public static IVisitable[] GetItems()
		{
			return new IVisitable[]
			{
				new NewPurchaseOrderRequest(new Product {Name = "iPhone"}, 5),
				new NewPurchaseOrderRequest(new Product {Name = "MacBookPro"}, 7),
				new NewPurchaseOrderRequest(new Product {Name = "MacBookAir"}, 1),

				new NewSalesOrderRequest("Apple", DateTime.Today).AddOrderLine("AwesomeApp v2", 2),
				new NewSalesOrderRequest("Microsoft", DateTime.Today).AddOrderLine("AwesomeApp v1", 1),

				new NewCustomerRequest("Deep Mind", "Computers")
			};
		}
	}
}