using Contracts.ConsoleUi;
using Contracts.Sales.CustomerOrders;
using iQuarc.AppBoot;

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
            var customers = customersSrv.GetCustomersWithOrders();

            console.WriteLine("The following customers were found:");
            console.WriteLine(string.Empty);

            foreach (var customer in customers)
            {
                console.WriteEntity(customer);
            }
        }

        public string MenuLabel => "Show Customers";
    }
}