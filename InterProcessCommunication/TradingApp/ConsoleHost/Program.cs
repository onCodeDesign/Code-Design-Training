using System;
using System.Configuration;
using Microsoft.Owin.Hosting;

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
                Console.WriteLine("Press ESC to stop the server\n");

                ConsoleKeyInfo keyInfo;
                do
                {
                    keyInfo = Console.ReadKey();
                }
                while (keyInfo.Key != ConsoleKey.Escape);
            }
        }        
    }
}
