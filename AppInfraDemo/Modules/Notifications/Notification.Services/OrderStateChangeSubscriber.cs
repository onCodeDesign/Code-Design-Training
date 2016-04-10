using System;
using Contracts.Notifications;
using Contracts.Sales;
using iQuarc.AppBoot;

namespace Notifications
{
    [Service("Order Default Subscriber", typeof (IStateChangeSubscriber<SalesOrderResult>))]
    class OrderStateChangeSubscriber : IStateChangeSubscriber<SalesOrderResult>
    {
        public void NewItem(SalesOrderResult item)
        {
            //TODO: We've got new order!!!
        }

        public void NotifyDeleted(SalesOrderResult item)
        {
            throw new NotImplementedException();
        }

        public void NotifyChanged(SalesOrderResult item)
        {
            throw new NotImplementedException();
        }
    }
}