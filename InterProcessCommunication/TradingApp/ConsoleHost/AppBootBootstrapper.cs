using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using AppBootEx;
using iQuarc.AppBoot;
using iQuarc.AppBoot.Unity;

namespace ConsoleHost
{
    public static class AppBootBootstrapper
    {
        public static Bootstrapper Run()
        {
            var assemblies = GetApplicationAssemblies().ToArray();
            Bootstrapper bootstrapper = new Bootstrapper(assemblies);
            bootstrapper.ConfigureWithUnity();
            bootstrapper.AddRegistrationBehavior(new ServiceProxyRegistrationBehavior());
            bootstrapper.AddRegistrationBehavior(new ServiceRegistrationBehavior());

            bootstrapper.Run();

            return bootstrapper;
        }

        private static IEnumerable<Assembly> GetApplicationAssemblies()
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            yield return Assembly.GetExecutingAssembly();

            foreach (string dll in Directory.GetFiles(path, "*.dll"))
            {
                string filename = Path.GetFileName(dll);
                if (filename != null && (filename.StartsWith("Contracts")
                                         || filename.StartsWith("Infra.")
                                         || filename.StartsWith("Proxies.")
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
    }
}