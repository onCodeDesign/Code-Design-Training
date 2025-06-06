using System;
using System.Collections.Generic;
using System.Linq;
using iQuarc.AppBoot;
using iQuarc.SystemEx;

namespace AppBootEx
{
    public sealed class ServiceProxyRegistrationBehavior : IRegistrationBehavior
    {
        public IEnumerable<ServiceInfo> GetServicesFrom(Type type)
        {
            IEnumerable<ServiceProxyAttribute> attributes = type.GetAttributes<ServiceProxyAttribute>(false);
            return attributes.Select(a => new ServiceInfo(a.ExportType, type, null, Lifetime.AlwaysNew));
        }
    }
}
