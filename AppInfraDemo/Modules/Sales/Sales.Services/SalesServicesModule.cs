using System;
using Contracts.Notifications;
using iQuarc.AppBoot;

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
	        IModule m = this;
			notificationService.NotifyAlive(m);
        }
    }
}