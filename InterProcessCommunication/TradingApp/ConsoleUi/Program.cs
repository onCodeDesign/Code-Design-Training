using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using Contracts.Infrastructure;
using Contracts.Portfolio.Services;
using Contracts.Sales.Services;
using iQuarc.AppBoot;
using iQuarc.AppBoot.Unity;
using iQuarc.SystemEx;
using Microsoft.Practices.ServiceLocation;

namespace ConsoleUi
{
    class Program
    {
        static void RunDemoApp()
        {
            Bootstrapp();
            ConsoleWriteRegisteredModules();

            DisplayPortfolioValue();

            PlaceLimitOrder();
        }

        private static IServiceLocator Bootstrapp()
        {
            var assemblies = GetApplicationAssemblies().ToArray();
            Bootstrapper bootstrapper = new Bootstrapper(assemblies);
            bootstrapper.ConfigureWithUnity();
            bootstrapper.AddRegistrationBehavior(new ServiceRegistrationBehavior());

            bootstrapper.Run();

            return bootstrapper.ServiceLocator;
        }

        private static IEnumerable<Assembly> GetApplicationAssemblies()
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            yield return Assembly.GetExecutingAssembly();

            foreach (string dll in Directory.GetFiles(path, "*.dll"))
            {
                string filename = Path.GetFileName(dll);
                if (filename != null && (filename.StartsWith("Contracts")
                                         || filename.StartsWith("Proxies.")
                                         || filename.StartsWith("Infra.")
                                         || filename.StartsWith("Portfolio.")
                                         || filename.StartsWith("Quotations.")
                                         || filename.StartsWith("Sales.")
                    ))
                {
                    Assembly assembly = Assembly.LoadFile(dll);
                    yield return assembly;
                }
            }
        }

        private static void DisplayPortfolioValue()
        {
            IPortfolioService srv = ServiceLocator.Current.GetInstance<IPortfolioService>();
            
            decimal value = srv.GetPortfolioValue();
            Console.WriteLine($"The portfolio value is: {value:C2}");
            ConsoleWriteSeparator();
        }

        private static void PlaceLimitOrder()
        {
            Console.WriteLine("Placing new buy limit order.");
            decimal price = ConsoleEx.AskInput<decimal>("Enter the limit price: "); //11.6

            IOrdersService srv = ServiceLocator.Current.GetInstance<IOrdersService>();
            srv.PlaceBuyLimitOrder("AAPL.S.NASDAQ",price, DateTime.UtcNow.AddDays(-1));
            Console.WriteLine("Your order request has been sent");
            Console.WriteLine("Your limit orders are:");
            var orders = srv.GetLimitOrders();
            orders.ForEach(ConsoleEx.WriteEntity);

            ConsoleWriteSeparator();
        }

        private static void ConsoleWelcome()
        {
            Console.WriteLine("This is the UI of this demo app!");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine();
        }

        private static void ConsoleGoodbye()
        {
            Console.WriteLine("");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("The demo has ended...");
            Console.ReadLine();
        }

        private static void ConsoleWriteSeparator()
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------");
        }

        private static void ConsoleWriteRegisteredModules()
        {
            Console.WriteLine("The following modules are loaded: ");

            IModulesHostContainer container = ServiceLocator.Current.GetInstance<IModulesHostContainer>();
            var modules = container.GetModules();
            modules.ForEach(m => Console.WriteLine($"\t{m}"));

            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------");
        }

        static void Main(string[] args)
        {
            ConsoleWelcome();
            try
            {
                RunDemoApp();
            }
            catch (Exception e) when (e.FirstInner<SocketException>() != null)
            {
                Console.WriteLine(e);
            }
            ConsoleGoodbye();
        }
    }
}
