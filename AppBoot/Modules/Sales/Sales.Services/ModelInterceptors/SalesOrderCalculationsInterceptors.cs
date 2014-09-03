using DataAccess;
using Sales.DataModel;
using Seido.AppBoot;

namespace Sales.ModelInterceptors
{
    [Service("SalesOrderCalculationsInterceptors", typeof(IEntityEntryFacade<SalesOrderHeader>))]
    class SalesOrderCalculationsInterceptors : EntityInterceptor<SalesOrderHeader>
    {
        public override void OnSave(IEntityEntryFacade<SalesOrderHeader> entry, IRepository repository)
        {
            base.OnSave(entry, repository);

            if (IsAddedOrModified(entry))
            {
                var order = entry.Entity;

                if (order.ShipDate == null)
                {
                    order.ShipDate = order.DueDate.AddDays(-2);
                }
            }
        }

        private static bool IsAddedOrModified(IEntityEntryFacade<SalesOrderHeader> entry)
        {
            return entry.State.HasFlag(EntityEntryStates.Added) || entry.State.HasFlag(EntityEntryStates.Modified);
        }
    }
}