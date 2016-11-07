using System.Collections.Generic;

namespace ConsoleDemo.Visitor.v3
{
	class CommandsRepository : IVisitor
	{
	    readonly List<object> toSave = new List<object>();

		public void SaveChanges()
		{
			using (IUnitOfWork uof = UofFactory.CreateUnitOfWork())
			{
				foreach (var entity in toSave)
				{
					uof.Add(entity);
				}

				uof.SaveChanges();
			}
			toSave.Clear();
		}

		public void VisitCustomerCommand(NewCustomerCommand customerCommand)
		{
			toSave.Add(customerCommand);
		}

		public void VisitSalesOrderCommand(NewSalesOrderCommand salesOrderCommand)
		{
			toSave.Add(salesOrderCommand);
		}

		public void VisitPurchaseOrderCommand(NewPurchaseOrderCommand purchaseOrder)
		{
			toSave.Add(purchaseOrder);
		}
	}
}