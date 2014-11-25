using System.Linq;
using DataAccess;
using iQuarc.AppBoot;
using Sales.DataModel;

namespace Sales.ModelInterceptors
{
    [Service("SalesOrderValidationInterceptor", typeof (IEntityInterceptor<SalesOrderHeader>))]
    class SalesOrderValidationInterceptor : EntityInterceptor<SalesOrderHeader>
    {
        public override void OnSave(IEntityEntryFacade<SalesOrderHeader> entry, IRepository repository)
        {
            base.OnSave(entry, repository);

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

        private static bool IsAddedOrModified(IEntityEntryFacade<SalesOrderHeader> entry)
        {
            return entry.State.HasFlag(EntityEntryStates.Added) || entry.State.HasFlag(EntityEntryStates.Modified);
        }
    }
}