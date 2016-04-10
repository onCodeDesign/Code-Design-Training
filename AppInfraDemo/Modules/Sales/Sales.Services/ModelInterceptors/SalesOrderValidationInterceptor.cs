using System.Linq;
using iQuarc.AppBoot;
using iQuarc.DataAccess;
using Sales.DataModel;

namespace Sales.ModelInterceptors
{
    [Service("SalesOrderValidationInterceptor", typeof (IEntityInterceptor<SalesOrderHeader>))]
    class SalesOrderValidationInterceptor : IEntityInterceptor<SalesOrderHeader>
    {
        public void OnSave(IEntityEntry<SalesOrderHeader> entry, IRepository repository)
        {
            if (IsAddedOrModified(entry))
            {
                var order = entry.Entity;

                if (string.IsNullOrEmpty(order.AccountNumber))
                    throw new InvalidOrderException();

                decimal taxes = order.TaxAmt;
                decimal total = order.SalesOrderDetails.Sum(ol => ol.LineTotal);

                if (taxes > total)
                    throw new InvalidOrderException();
            }
        }

        private static bool IsAddedOrModified(IEntityEntry<SalesOrderHeader> entry)
        {
            return entry.State.HasFlag(EntityEntryState.Added) || entry.State.HasFlag(EntityEntryState.Modified);
        }




	    public void OnLoad(IEntityEntry entry, IRepository repository)
	    {
		    throw new System.NotImplementedException();
	    }

	    public void OnSave(IEntityEntry entry, IRepository repository)
	    {
		    throw new System.NotImplementedException();
	    }

	    public void OnDelete(IEntityEntry entry, IRepository repository)
	    {
		    throw new System.NotImplementedException();
	    }

	    public void OnLoad(IEntityEntry<SalesOrderHeader> entry, IRepository repository)
	    {
		    throw new System.NotImplementedException();
	    }

	    public void OnDelete(IEntityEntry<SalesOrderHeader> entry, IRepository repository)
	    {
		    throw new System.NotImplementedException();
	    }
    }
}