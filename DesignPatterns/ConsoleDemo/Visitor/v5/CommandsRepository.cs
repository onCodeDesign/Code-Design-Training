using System.Collections.Generic;

namespace ConsoleDemo.Visitor.v5
{
    class CommandsRepository : IVisitor<NewPurchaseOrderCommand>,
        IVisitor<NewSalesOrderCommand>,
        IVisitor<NewCustomerCommand>
    {
        readonly List<object> toSave = new List<object>();

        public void SaveChanges()
        {
            using (IUnitOfWork uof = UofFactory.CreateUnitOfWork())
            {
                foreach (var entity in toSave)
                {
                    uof.Add(entity);
                }

                uof.SaveChanges();
            }
            toSave.Clear();
        }

        public void Visit(NewPurchaseOrderCommand element)
        {
            toSave.Add(element);
        }

        public void Visit(NewSalesOrderCommand element)
        {
            toSave.Add(element);
        }

        public void Visit(NewCustomerCommand element)
        {
            toSave.Add(element);
        }
    }
}