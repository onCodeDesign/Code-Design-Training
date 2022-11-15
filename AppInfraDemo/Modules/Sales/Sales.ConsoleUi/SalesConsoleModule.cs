using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iQuarc.AppBoot;

namespace Sales.ConsoleUi
{
    [Service(nameof(SalesConsoleModule), typeof(IModule))]
    public class SalesConsoleModule : IModule
    {
        public void Initialize()
        {
            Console.WriteLine("tests");
        }
    }
}
