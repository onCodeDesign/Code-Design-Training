using System;
using System.Reflection;
using Contracts.Location;
using iQuarc.AppBoot;
using Microsoft.Practices.ServiceLocation;

namespace ConsoleApplication
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            UnityBootstrapper bootstrapper = new UnityBootstrapper(new Assembly[] {});
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