using System;

namespace ConsoleDemo.Visitor.v5
{
    class NewCustomerCommandApporver : IVisitor<NewCustomerCommand>
    {
        public void Visit(NewCustomerCommand customerCommand)
        {
            Console.WriteLine($"We have new customer! {customerCommand.Name} welcome!");
        }
    }
}