using System;
using Contracts;
using Contracts.Sales;
using iQuarc.AppBoot;

namespace OrdersConsoleUi
{
    [Service(nameof(ShowCustomerOrdersCommand), typeof(IConsoleCommand))]
    public class ShowCustomerOrdersCommand : IConsoleCommand
    {
        private readonly IConsole console;
        private readonly IOrderingService orderingService;

        public ShowCustomerOrdersCommand(IOrderingService orderingService, IConsole console)
        {
            this.orderingService = orderingService;
            this.console = console;
        }

        public string Name => "Show orders for customer";
        public ConsoleKey TriggerKey => ConsoleKey.D1;
        public void Execute()
        {
            console.WriteLine("OrdersConsole: Show all orders function");
            string customerName = console.AskInput("Enter customer last name: ");

            SalesOrderInfo[] orders = orderingService.GetOrdersInfo(customerName);

            console.WriteLine($"Orders for customer {customerName}: "); //Test data: Abel | Smith | Adams
            foreach (SalesOrderInfo salesOrderInfo in orders)
            {
                console.WriteEntity(salesOrderInfo);
            }
        }
    }
}