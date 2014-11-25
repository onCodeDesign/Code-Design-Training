using System;
using System.Collections.Generic;
using System.Linq;
using Contracts.Sales;
using DataAccess;
using iQuarc.AppBoot;
using Sales.DataModel;

namespace Sales
{
    [Service(typeof (IOrderingService))]
    class OrderingService : IOrderingService
    {
        private readonly IRepository repository;
        private readonly IPriceCalculator calculator;
        private readonly IApprovalService orderApproval;

        public OrderingService(IRepository repository, IPriceCalculator calculator, IApprovalService orderApproval)
        {
            this.repository = repository;
            this.calculator = calculator;
            this.orderApproval = orderApproval;
        }


        public SalesOrder PlaceOrder(string customerName, OrderRequest request)
        {
            Customer c = GetCustomer(customerName);
            if (c == null)
                return new SalesOrder {State = OrderResultState.Invalid, Message = "Customer not found"};

            bool isValid = ValidateOrderRequest(c, request);

            if (isValid)
            {
                using (IUnitOfWork uof = repository.CreateUnitOfWork())
                {
                    SalesOrderHeader order
                        = uof.GetEntities<SalesOrderHeader>()
                                                .FirstOrDefault(o => o.CustomerID == c.CustomerID &&
                                                                     o.OrderDate.Month == DateTime.Now.Month);

                    if (order == null)
                    {
                        order = new SalesOrderHeader {Customer = c};
                        uof.Add(order);
                    }

                    AddRequestToOrder(request, order);

                    uof.SaveChanges();
                
                    return new SalesOrder { State = OrderResultState.Placed, OrderId = order.SalesOrderID };
                }
            }

            return new SalesOrder {State = OrderResultState.Invalid};
        }

        private void AddRequestToOrder(OrderRequest request, SalesOrderHeader order)
        {
            foreach (var requestedProduct in request.Products)
            {
                SalesOrderDetail line = new SalesOrderDetail
                {
                    ProductID = requestedProduct.Product.ProductId.Value
                    //TODO copy other info
                };

                order.SalesOrderDetails.Add(line);
            }
        }


        private Customer GetCustomer(string customerName)
        {
            return repository.GetEntities<Customer>()
                             .FirstOrDefault(customer => customer.Person.LastName == customerName);
        }

        private SalesOrderHeader GetOrder(OrderRequest request, int customerId)
        {
            //var dbOrder = repository.GetEntities<SalesOrderHeader>()
            //                      .FirstOrDefault(o => o.Customer.CustomerID == customerId &&
            //                                           o.OrderDate.Month == DateTime.Now.Date.Month);

            throw new NotImplementedException();
        }


        private bool ValidateOrderRequest(Customer customer, OrderRequest order)
        {
            bool productsExist = ValidateProducts(order);
            if (!productsExist) return false;

            var taxes = calculator.CalculateTaxes(order, customer);
            var discount = calculator.CalculateDiscount(order, customer);

            return orderApproval.Approve(new ApproveRequest
            {
                Customer = customer,
                Order = order,
                Taxes = taxes,
                Discount = discount
            });
        }

        private bool ValidateProducts(OrderRequest request)
        {
            var requestsByProductCode = request.Products
                        .Where(o => o.Product.ProductId == null && o.Product.Code != null);
            List<string> requiredCodes = requestsByProductCode.Select(p => p.Product.Code).ToList();
            var productsByCode = repository.GetEntities<Product>().Where(p => requiredCodes.Contains(p.ProductNumber));
           
            //TODO enrich each product from requiredByCode with the products from DB. If there are codes for which there are no products return false

            // validate that required by Id is correct

            // Validate that required both by Id and Code are consistent

            return true;
        }
    }
}