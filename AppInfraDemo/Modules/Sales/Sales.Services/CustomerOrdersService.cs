using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            return GetCustomersBy(c => true);
        }

        public IEnumerable<CustomerData> GetCustomersWithOrdersByName(string nameContains, string nameStartsWith)
        {
            Debug.Assert(!(string.IsNullOrEmpty(nameContains) && string.IsNullOrEmpty(nameStartsWith)));

            Expression<Func<Customer, bool>> filter;
            if (!string.IsNullOrEmpty(nameStartsWith) && !string.IsNullOrEmpty(nameContains))
                filter = c => c.Store.Name.StartsWith(nameStartsWith) && c.Store.Name.Contains(nameContains);
            else if (!string.IsNullOrEmpty(nameStartsWith))
                filter = c => c.Store.Name.StartsWith(nameStartsWith);
            else
                filter = c => c.Store.Name.Contains(nameContains);

            return GetCustomersBy(filter);
        }

        private IEnumerable<CustomerData> GetCustomersBy(Expression<Func<Customer, bool>> filter)
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