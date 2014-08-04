using Contracts.Notifications;
using Seido.AppBoot;

namespace Sales
{
    [Service("Sales Services Module", typeof(IModule))]
    class SalesServicesModule : IModule
    {
        private readonly INotificationService notificationService;

        public SalesServicesModule(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        public string Name
        {
            get { return "Sales Module"; }
        }

        public void Initialize()
        {
            notificationService.NotifyAlive(Name);
        }
    }
}