using System;
using iQuarc.AppBoot;

namespace AppBootEx
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ServiceProxyAttribute : Attribute
    {
        public ServiceProxyAttribute(Type exportType)
        {
            ExportType = exportType;
        }

        public Type ExportType { get; private set; }
    }
}