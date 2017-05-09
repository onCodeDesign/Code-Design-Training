using Contracts.Infrastructure;
using iQuarc.AppBoot;

namespace Proxies
{
    [Service(nameof(ProxiesModule), typeof(IModule))]
    class ProxiesModule : IModule
    {
        private readonly IModulesHostContainer container;

        public ProxiesModule(IModulesHostContainer container)
        {
            this.container = container;
        }

        public void Initialize()
        {
            container.RegisterModule($"Proxies Module ID: {HttpHelpers.ClientId}");
        }
    }
}