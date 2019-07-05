using Contracts.ConsoleUi;
using Contracts.Sales.CustomerOrders;
using iQuarc.AppBoot;
using iQuarc.SystemEx;

namespace Sales.ConsoleUi
{
    [Service(nameof(ShowCustomersCommand), typeof(IConsoleCommand))]
    class ShowCustomersCommand : IConsoleCommand
    {
        private readonly ICustomerOrdersService customersSrv;
        private readonly IConsole console;

        public ShowCustomersCommand(ICustomerOrdersService customersSrv, IConsole console)
        {
            this.customersSrv = customersSrv;
            this.console = console;
        }

        public void Execute()
        {
            string nameStartsWith = console.AskInput("Filter by Name starting with: ");
            string nameContains = console.AskInput("Filter by Name that contains: ");

            var customers = customersSrv.GetCustomersWithOrdersByName(nameContains, nameStartsWith);

            console.WriteLine("The following customers were found:");
            console.WriteLine(string.Empty);

            foreach (var customer in customers)
            {
                console.WriteEntity(customer);
            }
        }

        public string MenuLabel => "Show Customers with Orders";
    }
}