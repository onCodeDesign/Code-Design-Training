using Contracts.Infrastructure;
using iQuarc.AppBoot;

namespace Portfolio.Services
{
    [Service(nameof(PortfolioModule), typeof(IModule))]
    class PortfolioModule : IModule
    {
        private readonly IModulesHostContainer container;

        public PortfolioModule(IModulesHostContainer container)
        {
            this.container = container;
        }

        public void Initialize()
        {
            container.RegisterModule("Portfolio Module");
        }
    }
}