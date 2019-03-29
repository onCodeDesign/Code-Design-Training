using System;
using System.Collections.Generic;
using System.Linq;
using Contracts.Sales.CustomerOrders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sales;

namespace Sales.Services.UnitTests
{
    [TestClass]
    public class CustomerOrdersServiceTests
    {
        [TestMethod]
        public void GetCustomersWithOrders_NoCustomersWithOrders_EmptyResult()
        {
            CustomerOrdersService target;
            IEnumerable<CustomerData> actual = target.GetCustomersWithOrders();

            AssertIsEmpty(actual);
        }

        private void AssertIsEmpty(IEnumerable<CustomerData> actual)
        {
            Assert.IsTrue(!actual.Any(), "Enumerable is not empty as expected");
        }
    }
}
