using Contracts.ConsoleUi;
using Contracts.Sales.CustomerOrders;
using iQuarc.AppBoot;

namespace Sales.ConsoleUi
{
    [Service(nameof(CancelAllOrdersOfCustomer), typeof(IConsoleCommand))]
    class CancelAllOrdersOfCustomer : IConsoleCommand
    {
        private readonly IConsole console;
        private readonly ICustomerOrdersService ordersService;

        public CancelAllOrdersOfCustomer(IConsole console, ICustomerOrdersService ordersService)
        {
            this.console = console;
            this.ordersService = ordersService;
        }

        public void Execute()
        {
            string customer = console.AskInput("Enter customer name: ");
            ordersService.CancelAllOrdersForCustomer(customer);
        }

        public string MenuLabel => "Cancel All Orders for Customer";
    }
}