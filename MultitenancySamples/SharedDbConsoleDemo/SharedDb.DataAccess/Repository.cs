using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using iQuarc.DataAccess;

namespace SharedDb.DataAccess
{
    public class Repository : IRepository
    {
        private readonly iQuarc.DataAccess.Repository inner;
        private Dictionary<string, int> tenantsCache;

        public Repository()
            : this(new DbContextFactory(), new EmptyInterceptorsResolver())
        {
        }

        public Repository(IDbContextFactory contextFactory, IInterceptorsResolver interceptorsResolver)
        {
            inner = new iQuarc.DataAccess.Repository(contextFactory, interceptorsResolver);
        }

        public IQueryable<T> GetEntities<T>() where T : class
        {
            AssureIsInitialized();

            IQueryable<T> set = inner.GetEntities<T>();

            int tenantId = GetCurrentUserTenantId();
            Expression<Func<T, bool>> condition = BuildWhereExpression<T>(tenantId);

            return set.Where(condition);
        }

        private Expression<Func<T, bool>> BuildWhereExpression<T>(int tenantId)
        {
            if (IsTenantEntity<T>())
            {
                Expression<Func<ITenantEntity, int>> tenantIdSelector = entity => entity.TenantID;
                Expression<Func<int>> tenantIdParam = () => tenantId;

                var filterExpression = Expression.Lambda<Func<T, bool>>(
                    Expression.MakeBinary(ExpressionType.Equal,
                        Expression.Convert(tenantIdSelector.Body, typeof(int)),
                        tenantIdParam.Body),
                    tenantIdSelector.Parameters);

                return filterExpression;
            }
            else
            {
                Expression<Func<T, bool>> trueExpression = entity => true;
                return trueExpression;
            }
        }

        private bool IsTenantEntity<T>()
        {
            return typeof(T).GetInterfaces().Contains(typeof(ITenantEntity));
        }

        private int GetCurrentUserTenantId()
        {
            const string tenantKeyClaim = "tenant_key";
            Claim tenantClaim = ClaimsPrincipal.Current.FindFirst(tenantKeyClaim);
            var ternanId = tenantsCache[tenantClaim.Value];
            return ternanId;
        }

        public IUnitOfWork CreateUnitOfWork()
        {
            throw new NotImplementedException();
        }

        private void AssureIsInitialized()
        {
            if (tenantsCache == null)
                tenantsCache = inner.GetEntities<Tenant>()
                    .ToDictionary(t => t.Key, t => t.ID);
        }
    }
}