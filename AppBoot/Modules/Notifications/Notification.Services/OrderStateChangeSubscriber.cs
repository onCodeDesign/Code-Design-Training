using System;
using Contracts.Notifications;
using Contracts.Sales;
using Seido.AppBoot;

namespace Notifications
{
    [Service("Order Default Subscriber", typeof (IStateChangeSubscriber<SalesOrder>))]
    class OrderStateChangeSubscriber : IStateChangeSubscriber<SalesOrder>
    {
        public void NewItem(SalesOrder item)
        {
            //TODO: We've got new order!!!
        }

        public void NotifyDeleted<T>(T item)
        {
            throw new NotImplementedException();
        }

        public void NotifyChanged<T>(T item)
        {
            throw new NotImplementedException();
        }
    }
}