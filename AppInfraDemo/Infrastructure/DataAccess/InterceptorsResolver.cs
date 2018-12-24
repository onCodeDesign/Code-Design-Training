using System;
using System.Collections.Generic;
using System.Linq;
using iQuarc.SystemEx.Priority;
using iQuarc.AppBoot;
using Microsoft.Practices.ServiceLocation;

namespace DataAccess
{
    public interface IInterceptorsResolver
    {
        IEnumerable<IEntityInterceptor> GetGlobalInterceptors();
        IEnumerable<IEntityInterceptor> GetEntityInterceptors(Type entityType);
    }

    [Service(typeof(IInterceptorsResolver))]
    class InterceptorsResolver : IInterceptorsResolver
    {
        private readonly IServiceLocator serviceLocator;
        private static readonly Type interceptorGenericType = typeof (IEntityInterceptor<>);

        public InterceptorsResolver(IServiceLocator serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        public IEnumerable<IEntityInterceptor> GetGlobalInterceptors()
        {
            return serviceLocator.GetAllInstances<IEntityInterceptor>().OrderByPriority();
        }

        public IEnumerable<IEntityInterceptor> GetEntityInterceptors(Type entityType)
        {
            Type interceptorType = interceptorGenericType.MakeGenericType(entityType);
            return serviceLocator.GetAllInstances(interceptorType).Cast<IEntityInterceptor>();
        }
    }
}