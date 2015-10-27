using System.Reflection;
using iQuarc.AppBoot;
using iQuarc.AppBoot.Unity;

namespace ConsoleApplication
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var assemblies = GetApplicationAssemblies();
			Bootstrapper bootstrapper = new Bootstrapper(assemblies);
			bootstrapper.ConfigureWithUnity();

			bootstrapper.Run();
		}

		private static Assembly[] GetApplicationAssemblies()
		{
			//var assemblies = new[]
			//{
			//    typeof(Program).Assembly,
			//    Assembly.Load("")
			//}

			return new Assembly[] {};
		}
	}
}