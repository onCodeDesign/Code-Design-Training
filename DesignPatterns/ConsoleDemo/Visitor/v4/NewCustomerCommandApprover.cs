using System;

namespace ConsoleDemo.Visitor.v4
{
	class NewCustomerCommandApprover : Visitor
	{
		private ICrmService crmService;

		public NewCustomerCommandApprover(ICrmService crmService)
		{
			this.crmService = crmService;
		}

		public override void VisitCustomerCommand(NewCustomerCommand customerCommand)
		{
			Console.WriteLine($"We have new customer! {customerCommand.Name} welcome!");
		}

		public NewCustomerCommandApprover()
		{
		}
	}
}