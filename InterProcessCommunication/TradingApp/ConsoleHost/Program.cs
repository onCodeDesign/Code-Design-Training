using System;
using System.Configuration;
using Contracts.Infrastructure;
using iQuarc.SystemEx;
using Microsoft.Owin.Hosting;
using Microsoft.Practices.ServiceLocation;

namespace ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = ConfigurationManager.AppSettings["BaseAddress"];

            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Console.WriteLine($"Server runs at: {baseAddress}");
                ConsoleWriteRegisteredModules();
                Console.WriteLine("Press ESC to stop the server\n");

                ConsoleKeyInfo keyInfo;
                do
                {
                    keyInfo = Console.ReadKey();
                }
                while (keyInfo.Key != ConsoleKey.Escape);
            }
        }

        private static void ConsoleWriteRegisteredModules()
        {
            Console.WriteLine("The following modules are loaded: ");

            IModulesHostContainer container = ServiceLocator.Current.GetInstance<IModulesHostContainer>();
            var modules = container.GetModules();
            modules.ForEach(m => Console.WriteLine($"\t{m}"));

            Console.WriteLine();
        }
    }
}
