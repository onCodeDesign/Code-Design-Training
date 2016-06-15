using System.Collections.Generic;

namespace ConsoleDemo.Visitor.v3
{
	class RequestsRepositoryVisitor : IVisitor
	{
		List<object> toSave = new List<object>();

		public void SaveChanges()
		{
			using (IUnitOfWork uof = UofFacotry.CreateUnitOfWork())
			{
				foreach (var entity in toSave)
				{
					uof.Add(entity);
				}

				uof.SaveChanges();
			}
			toSave.Clear();
		}

		public void VisitCustomerRequest(NewCustomerRequest customerRequest)
		{
			toSave.Add(customerRequest);
		}

		public void VisitSalesOrderRequest(NewSalesOrderRequest salesOrderRequest)
		{
			toSave.Add(salesOrderRequest);
		}

		public void VisitPurchaseOrderRequest(NewPurchaseOrderRequest purchaseOrder)
		{
			toSave.Add(purchaseOrder);
		}
	}
}