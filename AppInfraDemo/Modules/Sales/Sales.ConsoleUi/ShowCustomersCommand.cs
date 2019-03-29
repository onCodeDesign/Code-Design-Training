using Contracts.ConsoleUi;
using iQuarc.AppBoot;

namespace Sales.ConsoleUi
{
    [Service(nameof(ShowCustomersCommand), typeof(IConsoleCommand))]
    class ShowCustomersCommand : IConsoleCommand
    {
        public void Execute()
        {
        }

        public string MenuLabel => "Show Customers";
    }
}