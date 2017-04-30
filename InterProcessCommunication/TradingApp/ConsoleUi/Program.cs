using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Portfolio.Services;
using Microsoft.Practices.ServiceLocation;

namespace ConsoleUi
{
    class Program
    {
        static void Main(string[] args)
        {
            Welcome();

            DisplayPortfolioValue();

            Goodbye();
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
