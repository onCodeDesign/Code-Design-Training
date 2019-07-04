using Contracts.Notifications;
using iQuarc.AppBoot;
using iQuarc.SystemEx.Priority;

namespace Notifications
{
    [Priority(Priorities.High)]
    [Service(nameof(NotificationsModule), typeof(IModule))]
    class NotificationsModule :IModule
    {
        private readonly INotificationService notSrv;

        public NotificationsModule(INotificationService notSrv)
        {
            this.notSrv = notSrv;
        }

        public void Initialize()
        {
            notSrv.NotifyAlive((IModule) this);
        }
    }
}