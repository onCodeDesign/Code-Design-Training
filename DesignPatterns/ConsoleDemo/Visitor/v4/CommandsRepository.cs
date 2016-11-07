using System.Collections.Generic;

namespace ConsoleDemo.Visitor.v4
{
	class CommandsRepository : Visitor
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

		public override void VisitCustomerCommand(NewCustomerCommand customerCommand)
		{
			toSave.Add(customerCommand);
		}

		public override void VisitSalesOrderCommand(NewSalesOrderCommand salesOrderCommand)
		{
			toSave.Add(salesOrderCommand);
		}

		public override void VisitPurchaseOrderCommand(NewPurchaseOrderCommand purchaseOrder)
		{
			toSave.Add(purchaseOrder);
		}
	}
}