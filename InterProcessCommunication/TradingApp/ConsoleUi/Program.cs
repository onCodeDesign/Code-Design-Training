using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Contracts.Portfolio.Services;
using iQuarc.AppBoot;
using iQuarc.AppBoot.Unity;
using Microsoft.Practices.ServiceLocation;

namespace ConsoleUi
{
    class Program
    {
        static void Main(string[] args)
        {
            Welcome();

            Bootstrapp();

            DisplayPortfolioValue();

            Goodbye();
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
            Console.WriteLine($"The portfolio value is: {value:F3}");
        }

        private static void Welcome()
        {
            Console.WriteLine("This is the UI of this demo app!");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine();
        }

        private static void Goodbye()
        {
            Console.WriteLine("");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("The demo has ended...");
            Console.ReadLine();
        }
    }
}
