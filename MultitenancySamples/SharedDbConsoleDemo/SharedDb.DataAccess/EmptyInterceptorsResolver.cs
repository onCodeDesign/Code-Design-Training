using System;
using System.Collections.Generic;
using System.Linq;
using iQuarc.DataAccess;

namespace SharedDb.DataAccess
{
    public class EmptyInterceptorsResolver : IInterceptorsResolver
    {
        public IEnumerable<IEntityInterceptor> GetGlobalInterceptors()
        {
            return Enumerable.Empty<IEntityInterceptor>();
        }

        public IEnumerable<IEntityInterceptor> GetEntityInterceptors(Type entityType)
        {
            return Enumerable.Empty<IEntityInterceptor>();
        }
    }
}