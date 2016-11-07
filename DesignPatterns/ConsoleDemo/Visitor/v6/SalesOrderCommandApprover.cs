using System;

namespace ConsoleDemo.Visitor.v6
{
	class SalesOrderCommandApprover : IVisitor<NewSalesOrderCommand>
	{
	    private readonly IVisitor visitor;

	    public SalesOrderCommandApprover()
	    {
	        visitor = new Visitor(this);
	    }

	    public void Visit(NewSalesOrderCommand salesOrderCommand)
		{
			Console.WriteLine($"Sales Order from {salesOrderCommand.CustomerCode} was approved.");
		}

	    public IVisitor AsVisitor()
	    {
	        return visitor;
	    }
	}
}