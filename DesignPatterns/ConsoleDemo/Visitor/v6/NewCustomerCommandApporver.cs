using System;

namespace ConsoleDemo.Visitor.v6
{
    class NewCustomerCommandApporver : IVisitor<NewCustomerCommand>
    {
        private readonly IVisitor visitor;

        public NewCustomerCommandApporver()
        {
            visitor = new Visitor(this);
        }

        public void Visit(NewCustomerCommand customerCommand)
        {
            Console.WriteLine($"We have new customer! {customerCommand.Name} welcome!");
        }

        public IVisitor AsVisitor()
        {
            return visitor;
        }
    }
}