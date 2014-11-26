using System;
using System.Reflection;
using iQuarc.AppBoot;

namespace ConsoleApplication
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            UnityBootstrapper bootstrapper = new UnityBootstrapper(new Assembly[] {});
            var assemblies = GetApplicationAssemblies();

            bootstrapper.Run();
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