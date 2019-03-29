using System;
using System.Collections.Generic;
using System.Linq;
using Contracts.Sales.CustomerOrders;
using iQuarc.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sales;
using Sales.DataModel;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetCustomersWithOrders_NoCustomersWithOrders_EmptyResult()
        {
            CustomerOrdersService target = GetTarget();

            IEnumerable<CustomerData> actual = target.GetCustomersWithOrders();

            AssertIsEmpty(actual);
        }

        [TestMethod]
        public void GetCustomersWithOrder_SomeCustomersHaveOrders_NotEmptyResult()
        {
            var salesOrderHeaders = new List<SalesOrderHeader>();   
            salesOrderHeaders.Add(new SalesOrderHeader());
            salesOrderHeaders.Add(new SalesOrderHeader());

            Customer[] customers = new[]
            {
                new Customer {SalesOrderHeaders = salesOrderHeaders,
                    StoreID = 1,
                    Store = new Store{Name = "Store1"}
                },
                new Customer {SalesOrderHeaders = salesOrderHeaders, StoreID = 2, Store = new Store{Name = "Store2"}},
            };

            CustomerOrdersService target = GetTarget(customers);

            IEnumerable<CustomerData> actual = target.GetCustomersWithOrders();

            AssertNotIsEmpty(actual);
        }

        private void AssertNotIsEmpty(IEnumerable<CustomerData> actual)
        {
            Assert.IsTrue(actual.Count()!=0);
        }

        private CustomerOrdersService GetTarget(params Customer[] customers)
        {
            Mock<IRepository> repStub = new Mock<IRepository>();
            repStub.Setup(r => r.GetEntities<Customer>())
                .Returns(customers.AsQueryable());


            return new CustomerOrdersService(repStub.Object);
        }

        private void AssertIsEmpty(IEnumerable<CustomerData> actual)
        {
            Assert.IsTrue(!actual.Any());
        }
    }
}
