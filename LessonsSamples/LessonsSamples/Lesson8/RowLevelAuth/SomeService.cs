using System.Collections;
using System.Data.Entity;
using System.Linq;
using LessonsSamples.Lesson7.GoodClasses.DataModel;

namespace LessonsSamples.Lesson8.RowLevelAuth
{
    class SomeService
    {
        private readonly IRepository repository;

        public SomeService(IRepository repository)
        {
            this.repository = repository;
        }

        public ICollection GetOrderData(int orderId)
        {
            var q = repository.GetEntities<OrderLine>()
                .Where(ol => ol.OrderID == orderId);

            return q.ToArray();
        }

        public ICollection GetOrderData_(int orderId)
        {
            var q = repository.GetEntities<Order>()
                .Include(o => o.OrderLines)
                .Where(o => o.ID == orderId);


            var q2 = repository.GetEntities<Order>()
                .Select(o => new
                {
                    o.ID,
                    o.OrderLines,
                    o.OrderDate
                })
                .Where(o => o.ID == orderId);


            return q.ToArray();
        }
    }
}