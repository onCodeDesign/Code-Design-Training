using System.Collections.Generic;
using Contracts.Infrastructure;
using iQuarc.AppBoot;

namespace ConsoleHost
{
    [Service(typeof(IModulesHostContainer), Lifetime.Application)]
    class ModulesHostContainer : IModulesHostContainer
    {
        private readonly List<string> modules =new List<string>();

        public void RegisterModule(string moduleName)
        {
            modules.Add(moduleName);
        }

        public IEnumerable<string> GetModules()
        {
            return modules;
        }
    }
}