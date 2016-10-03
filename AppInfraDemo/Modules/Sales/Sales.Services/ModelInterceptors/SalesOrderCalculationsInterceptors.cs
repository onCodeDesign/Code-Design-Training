using iQuarc.AppBoot;
using iQuarc.DataAccess;
using Sales.DataModel;

namespace Sales.ModelInterceptors
{
    [Service("SalesOrderCalculationsInterceptors", typeof(IEntityInterceptor<SalesOrderHeader>))]
    class SalesOrderCalculationsInterceptors : IEntityInterceptor<SalesOrderHeader>
    {
        public void OnSave(IEntityEntry<SalesOrderHeader> entry, IUnitOfWork unitOfWork)
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

        public void OnDelete(IEntityEntry<SalesOrderHeader> entry, IUnitOfWork unitOfWork)
        {
            throw new System.NotImplementedException();
        }

        private static bool IsAddedOrModified(IEntityEntry<SalesOrderHeader> entry)
        {
            return entry.State.HasFlag(EntityEntryState.Added) || entry.State.HasFlag(EntityEntryState.Modified);
        }

        public void OnSave(IEntityEntry entry, IUnitOfWork  unitOfWork)
        {
            OnSave(entry.Convert<SalesOrderHeader>(), unitOfWork);
        }

        public void OnLoad(IEntityEntry<SalesOrderHeader> entry, IRepository repository)
        {
        }

        public void OnLoad(IEntityEntry entry, IRepository repository)
        {
        }

        public void OnDelete(IEntityEntry entry, IUnitOfWork unitOfWork)
        {
        }

        public void OnDelete(IEntityEntry<SalesOrderHeader> entry, IRepository repository)
	    {
	    }
    }
}