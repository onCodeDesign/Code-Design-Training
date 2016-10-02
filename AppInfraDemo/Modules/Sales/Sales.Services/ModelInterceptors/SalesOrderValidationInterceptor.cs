using System.Linq;
using iQuarc.AppBoot;
using iQuarc.DataAccess;
using Sales.DataModel;

namespace Sales.ModelInterceptors
{
    [Service("SalesOrderValidationInterceptor", typeof (IEntityInterceptor<SalesOrderHeader>))]
    class SalesOrderValidationInterceptor : IEntityInterceptor<SalesOrderHeader>
    {
        public void OnSave(IEntityEntry<SalesOrderHeader> entry, IUnitOfWork unitOfWork)
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

        public void OnSave(IEntityEntry entry, IUnitOfWork unitOfWork)
        {
            this.OnSave(entry.Convert<SalesOrderHeader>(), unitOfWork);
        }

        public void OnLoad(IEntityEntry entry, IRepository repository)
	    {
	    }

        public void OnLoad(IEntityEntry<SalesOrderHeader> entry, IRepository repository)
	    {
	    }

        public void OnDelete(IEntityEntry entry, IUnitOfWork unitOfWork)
        {
        }

        public void OnDelete(IEntityEntry<SalesOrderHeader> entry, IUnitOfWork unitOfWork)
        {
        }
    }
}