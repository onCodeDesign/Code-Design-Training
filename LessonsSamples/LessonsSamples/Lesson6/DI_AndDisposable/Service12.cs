using System;
using System.Collections.Generic;
using System.Linq;

namespace LessonsSamples.Lesson6.DI_AndDisposable
{
    class Service12
    {
        // IRepositoryFactory is not IDisposable, so there is nothing to dispose from the Service class perspective
        //   the repository instances it will return are disposable, but there is explicit code which asks for an instance.
        private readonly IRepositoryFactory repFactory;

        public Service12(IRepositoryFactory repFactory)
        {
            this.repFactory = repFactory;
        }

        public decimal GetHighRiskOrdersAmount(int year)
        {
            using (IRepository repository = repFactory.CreateRepository())
            {
                IQueryable<Order> orders = GetHighValueOrders(repository)
                    .Where(o => o.Year == year);

                decimal ammount = 0;
                foreach (var order in orders) // lets say I'm keen on performance and I only want to iterate once through the resultset. / lets say I'm keen on performance and I only want to iterate once through the resultset. 
                {
                    // If I would use the return order.ToArray().Count(IsHighRisk) there is one iteration for ToArray and one for Count()
                    if (IsHighRisk(order))
                        ammount += order.OrderLines.Sum(ol => ol.Ammount); // I only read DB the orderlines of high risk orders. I expect that only 10% of orders are high risk
                }

                return ammount;
            }
        }

        public int CountHighRiskOrders(int startingWith, int endingWith)
        {
            using (IRepository rep = repFactory.CreateRepository())
            {
                var orders = GetHighValueOrders(rep)
                    .Where(o => o.Year >= startingWith && o.Year <= endingWith);

                int count = 0;
                foreach (var o in orders) // lets say I'm keen on performance and I only want to iterate once through the resultset. 
                {
                    // If I would use the return order.ToArray().Count(IsHighRisk) there is one iteration for ToArray and one for Count()
                    if (IsHighRisk(o))
                        count++;
                }

                return count;
            }
        }

        //public ICollection<T> GetOrders<T>(Expression<Func<T, bool>>  where) int startingWith, int endingWith)


        public IEnumerable<Order> GetOrders(int startingWith, int endingWith)
        {
            using (IRepository rep = repFactory.CreateRepository())
            {
                return GetHighValueOrders(rep)
                    .Where(order => order.Year >= startingWith && order.Year <= endingWith);
            }
            // Is the above code correct? Have another look

            // the returned IEnumerable will be enumerated by the caller code after the rep.Dispose() --> error. 

            // To avoid this more (uncontrollable) approaches may be taken --> error prone --> low maintainability
            //      - receive the repository instance created by the caller code. The caller code needs to dispose it, not me
            //      - call .ToList() on this, but still return it as IEnumerable<>. What happens, when the caller iterates the order.OrderLines? --> error
            //      - this function is refactored to only send a query that should be wrapped and executed by the caller
        }

        public void UpdateHighRiskOrders(int year)
        {
            using (IUnitOfWork uof = repFactory.CreateUnitOfWork())
            {
                var orders = GetHighValueOrders(uof) // IUnitOfWork : IRepository, so I can reuse the GetHighValueOrders
                    .Where(o => o.Year == year && o.Status == Status.PreCalculated);

                foreach (var order in orders)
                {
                    if (IsHighRisk(order))
                    {
                        foreach (var orderLine in order.OrderLines) // I only read from DB the orderlines of the high risk orders
                        {
                            orderLine.Status = Status.Reviewed;
                        }
                    }
                }

                uof.SaveChanges();
            }
        }

        // this functions wants to reuse the is HighValue evaluation. The evaluation of the condition can translate into a WHERE filtering in SQL in the database
        private IQueryable<Order> GetHighValueOrders(IRepository repository)
        {
            var orders = from o in repository.GetEntities<Order>()
                         join ol in repository.GetEntities<OrderLine>() on o.Id equals ol.OrderId
                         where ol.Ammount > 100
                         select o;


            //IQueryable<Order> orders = repository.GetEntities<Order>()
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
}