using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Contracts.Sales.CustomerOrders;
using iQuarc.AppBoot;
using iQuarc.DataAccess;
using Sales.DataModel;

namespace Sales
{
    [Service(typeof(ICustomerOrdersService))]
    class CustomerOrdersService : ICustomerOrdersService
    {
        private readonly IRepository rep;

        public CustomerOrdersService(IRepository rep)
        {
            this.rep = rep;
        }

        public IEnumerable<CustomerData> GetCustomersWithOrders()
        {
            var query = rep.GetEntities<Customer>()
                .Where(c => c.SalesOrderHeaders.Any() && c.StoreID != null)
                .OrderBy(c => c.Store.Name)
                .Select(c => new CustomerData
                {
                    Id = c.CustomerID,
                    AccountNumber = c.AccountNumber,
                    Name = c.Store.Name
                });

            return query.AsEnumerable();
        }

        public IEnumerable<CustomerData> GetCustomersBy(Expression<Func<Customer, bool>> filter)
        {
            var query = rep.GetEntities<Customer>()
                .Where(c => c.SalesOrderHeaders.Any() && c.StoreID != null)
                .Where(filter)
                .OrderBy(c => c.Store.Name)
                .Select(c => new CustomerData
                {
                    Id = c.CustomerID,
                    AccountNumber = c.AccountNumber,
                    Name = c.Store.Name
                });

            return query.AsEnumerable();
        }
    }
}