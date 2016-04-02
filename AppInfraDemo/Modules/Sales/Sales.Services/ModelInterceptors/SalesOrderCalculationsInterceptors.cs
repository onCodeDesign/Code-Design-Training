using iQuarc.AppBoot;
using iQuarc.DataAccess;
using Sales.DataModel;

namespace Sales.ModelInterceptors
{
    [Service("SalesOrderCalculationsInterceptors", typeof(IEntityInterceptor<SalesOrderHeader>))]
    class SalesOrderCalculationsInterceptors : IEntityInterceptor<SalesOrderHeader>
    {
        public void OnSave(IEntityEntry<SalesOrderHeader> entry, IRepository repository)
        {
            if (IsAddedOrModified(entry))
            {
                var order = entry.Entity;

                if (order.ShipDate == null)
                {
                    order.ShipDate = order.DueDate.AddDays(-2);
                }
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