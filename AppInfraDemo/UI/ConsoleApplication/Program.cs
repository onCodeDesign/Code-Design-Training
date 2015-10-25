using System;
using System.Reflection;
using Contracts.Location;
using iQuarc.AppBoot;
using iQuarc.AppBoot.Unity;
using Microsoft.Practices.ServiceLocation;

namespace ConsoleApplication
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Bootstrapper bootstrapper = new Bootstrapper(new Assembly[] {});
	        bootstrapper.ConfigureWithUnity();

            var assemblies = GetApplicationAssemblies();

            bootstrapper.Run();

	        ILocationService service = ServiceLocator.Current.GetInstance<ILocationService>();
	        service.GetCoordinates("some city", "street name", "house number");
        }

        private static Assembly[] GetApplicationAssemblies()
        {
            //var assemblies = new[]
            //{
            //    typeof(Program).Assembly,
            //    Assembly.Load("")
            //}

            throw new NotImplementedException();
        }
    }
}