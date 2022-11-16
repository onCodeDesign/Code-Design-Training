using System;
using System.Collections.Generic;
using System.Linq;
using Contracts.Sales;
using iQuarc.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sales.DataModel;

namespace Sales.Services.UnitTests
{
    [TestClass]
    public class OrderingServiceTests
    {
        [TestMethod]
        public void GetCustomersWithOrders_CustomersWithMoreOrders_OrderedByStore()
        {
            RepositoryStub repStub = new RepositoryStub
            {
                Customers = new[]
                {
                    new Customer
                    {
                        CustomerID = 1,
                        AccountNumber = "some number",
                        SalesOrderHeaders = new List<SalesOrderHeader>
                        {
                            new SalesOrderHeader
                            {
                                Customer = new Customer
                                {
                                    Store = new Store {Name = "Cba"},
                                    StoreID = 1
                                }
                            },
                        },
                        StoreID = 1,
                        Store = new Store {Name = "Cba"}
                    },
                    new Customer
                    {
                        CustomerID = 2,
                        AccountNumber = "some number",
                        SalesOrderHeaders = new List<SalesOrderHeader>
                        {
                            new SalesOrderHeader
                            {
                                Customer = new Customer
                                {
                                    Store = new Store {Name = "Abc"},
                                    StoreID = 2
                                }
                            },
                        },
                        StoreID = 2,
                        Store = new Store {Name = "Abc"},
                    }
                }
            };

            PriceCalculatorStub priceCalcStub = new PriceCalculatorStub();
            ApprovalServiceStub approvalService = new ApprovalServiceStub();
            OrderingService target = new OrderingService(repStub, priceCalcStub, approvalService);
            CustomerInfo[] actual = target.GetCustomersWithOrders();

            var actualStoreNames = actual.Select(c => c.StoreName).ToArray();


            Assert.AreEqual("Abc", actualStoreNames[0]);
            Assert.AreEqual("Cba", actualStoreNames[1]);
        }
    }

    public class ApprovalServiceStub : IApprovalService
    {
        public bool Approve(ApproveRequest approveRequest)
        {
            throw new NotImplementedException();
        }
    }

    public class PriceCalculatorStub : IPriceCalculator
    {
        public decimal CalculateTaxes(OrderRequest o, Customer c)
        {
            throw new NotImplementedException();
        }

        public decimal CalculateDiscount(OrderRequest o, Customer c)
        {
            throw new NotImplementedException();
        }
    }

    public class RepositoryStub : IRepository
    {
        public Customer[] Customers { get; set; }

        public IQueryable<T> GetEntities<T>() where T : class
        {
            return Customers.Cast<T>().AsQueryable();
        }

        public IUnitOfWork CreateUnitOfWork()
        {
            throw new NotImplementedException();
        }
    }
}