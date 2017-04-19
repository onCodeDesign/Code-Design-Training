using Contracts.Infrastructure;
using iQuarc.AppBoot;

namespace Quotations.Services
{
    [Service(nameof(QuotationsModule), typeof(IModule))]
    class QuotationsModule : IModule
    {
        private readonly IModulesHostContainer container;

        public QuotationsModule(IModulesHostContainer container)
        {
            this.container = container;
        }

        public void Initialize()
        {
            container.RegisterModule("Quotations Module");
        }
    }
}