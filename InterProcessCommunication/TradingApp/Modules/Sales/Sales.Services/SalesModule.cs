using Contracts.Infrastructure;
using iQuarc.AppBoot;

namespace Sales.Services
{
    [Service(nameof(SalesModule), typeof(IModule))]
    class SalesModule : IModule
    {
        private readonly IModulesHostContainer container;

        public SalesModule(IModulesHostContainer container)
        {
            this.container = container;
        }

        public void Initialize()
        {
            container.RegisterModule("Sales Module");
        }
    }
}