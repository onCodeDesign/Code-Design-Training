using System.Collections.Generic;
using System.Linq;

namespace LessonsSamples.Lesson6.DI_AndDisposable
{
    class Service11
    {
        // The concern of calling repository.Dispose() is not in this service (the code all devs write)
        //       It is separated and implemented in another component, and it will call when the DIC that created this instance is Disposed
        private readonly IRepository repository;

        public Service11(IRepository repository)
        {
            this.repository = repository;
        }

        public decimal GetHighRiskOrdersAmount(int year)
        {
            IQueryable<Order> orders = GetHighValueOrders()
                .Where(o => o.Year == year);

            decimal ammount = 0;
            foreach (var order in orders)
            {
                if (IsHighRisk(order))
                    ammount += order.OrderLines.Sum(ol => ol.Ammount);
            }

            return ammount;
        }

        public int CountHighRiskOrders(int startWithYear, int endWithYear)
        {
            var orders = GetHighValueOrders()
                .Where(o => o.Year >= startWithYear && o.Year <= endWithYear);

            int count = 0;
            foreach (var o in orders) // lets say I'm keen on performance and I only want to iterate once through the resultset. 
            {
                // If I would use the return order.ToArray().Count(IsHighRisk) there is one iteration for ToArray and one for Count()
                if (IsHighRisk(o))
                    count++;
            }

            return count;
        }

        public IEnumerable<Order> GetOrders(int startingWith, int endingWith)
        {
            return GetHighValueOrders()
                .Where(order => order.Year >= startingWith && order.Year <= endingWith);

            // this works
            // the caller has a reference to this calls, therefore it has a reference to the repository which was not Disposed()
            // I have the flexibility to: 
            //   - return IEnumerable, so the query executes when iterated first
            //   - return IQueryable, so the query can be enriched by the client before execution
            //   - return IEnumerable, but with an List underneath so the query is already executed
        }

        public void UpdateHighRiskOrders(int year)
        {
            using (IUnitOfWork uof = repository.CreateUnitOfWork())
            {
                var orders = GetHighValueOrders(uof)
                    .Where(o => o.Year == year && o.Status == Status.PreCalculated);

                foreach (var order in orders.Where(IsHighRisk))
                {
                    foreach (var orderLine in order.OrderLines)
                    {
                        orderLine.Status = Status.Reviewed;
                    }
                }

                uof.SaveChanges();
            }
        }

        private IQueryable<Order> GetHighValueOrders(IRepository uof = null)
        {
            IRepository r = uof ?? repository;

            var orders = from o in r.GetEntities<Order>()
                         join ol in r.GetEntities<OrderLine>() on o.Id equals ol.OrderId
                         where ol.Ammount > 100
                         select o;


            //IQueryable<Order> orders = r.GetEntities<Order>()
            //                                     .Where(o => o.OrderLines.Any(ol => ol.Ammount > 100));
            return orders;
        }

        private bool IsHighRisk(Order order)
        {
            // this implements some business logic that says if this order is of a high risk
            // This logic cannot be translated into a SQL query, it may imply calling other services to evaluate the condition
            // I assume it is mainly related on the history we have with the client that has placed the order, and not the order itself
            throw new NotImplementedException();
        }
    }

    class OrderRow
    {
        public IEnumerable<OrderLine> OrderLines { get; set; }
        public string Header { get; set; }
    }
}