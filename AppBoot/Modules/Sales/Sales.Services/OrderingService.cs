using System;
using System.Linq;
using Contracts.Sales;
using DataAccess;
using Sales.DataModel;
using Seido.AppBoot;

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


        public SalesOrder PlaceOrder(string customerName, SalesOrderRequest request)
        {
            Customer c = GetCustomer(customerName);
            if (c == null)
                return new SalesOrder {State = OrderResultState.Invalid, Message = "Customer not found"};

            SalesOrderHeader o = GetOrder(request, c.CustomerID);

            bool isValid = ValidateOrder(c, o);

            if (isValid)
            {
                int id = SaveOrder(c, o);
                return new SalesOrder {State = OrderResultState.Success, OrderId = id};
            }

            return new SalesOrder {State = OrderResultState.Failure};
        }

        private Customer GetCustomer(string customerName)
        {
            return repository.GetEntities<Customer>()
                             .FirstOrDefault(customer => customer.Person.LastName == customerName);
        }

        private SalesOrderHeader GetOrder(SalesOrderRequest request, int customerId)
        {
            //var dbOrder = repository.GetEntities<SalesOrderHeader>()
            //                      .FirstOrDefault(o => o.Customer.CustomerID == customerId &&
            //                                           o.OrderDate.Month == DateTime.Now.Date.Month);
          
            throw new NotImplementedException();
        }


        private bool ValidateOrder(Customer customer, SalesOrderHeader order)
        {
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

        private int SaveOrder(Customer customer, SalesOrderHeader order)
        {
            throw new NotImplementedException();
        }
    }
}