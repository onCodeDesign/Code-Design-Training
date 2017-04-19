using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Claims;

namespace LessonsSamples.Lesson8.RowLevelAuth
{
    class RowAuthPoliciesContainer : IRowAuthPoliciesContainer
    {
        readonly Dictionary<Type, object> policies = new Dictionary<Type, object>();

        public RowAuthPolicy<TEntity, TProperty> Register<TEntity, TProperty>(Expression<Func<TEntity, TProperty>> selector)
        {
            var policy = new RowAuthPolicy<TEntity, TProperty>(selector, this);
            policies.Add(policy.EntityType, policy);
            return policy;
        }

        public IRowAuthPolicy<TEntity> GetPolicy<TEntity>()
        {
            return (IRowAuthPolicy<TEntity>) policies[typeof(TEntity)];
        }

        public bool HasPolicy<TEntity>()
        {
            return policies.ContainsKey(typeof(TEntity));
        }

       public static IRowAuthPoliciesContainer ConfigureRowAuthPolicies()
       {
           return new RowAuthPoliciesContainer()
               .Register<Order, int>(o => o.Customer.AreadID).Match(CurrentUserAreaId)
               .Register<Customer, int>(c => c.AreadID).Match(CurrentUserAreaId)
               .Register<Product, int>(p => p.Producer.AreaID).Match(CurrentUserAreaId)
               .Register<OrderLine, int>(ol => ol.Product.Producer.AreaID).Match(CurrentUserAreaId)
               .Register<SalesArea, string>(sa => sa.CountryCode).When(CurrentUserIsSales).Match(CurrentUserCountryCode);
       }

        private static int CurrentUserAreaId()
        {
            const string areaKeyClaim = "area_key";
            Claim areaClaim = ClaimsPrincipal.Current.FindFirst(areaKeyClaim);
            int areaId = ClaimsValuesCache.GetArea(areaClaim.Value);
            return areaId;
        }

        private static string CurrentUserCountryCode()
        {
            const string countryKeyClaim = "country_key";
            Claim countryClaim = ClaimsPrincipal.Current.FindFirst(countryKeyClaim);
            string countryCode = ClaimsValuesCache.GetCountryCode(countryClaim.Value);
            return countryCode;
        }

        private static bool CurrentUserIsSales()
        {
            throw new NotImplementedException();
        }
    }

    internal class ClaimsValuesCache
    {
        public static int GetArea(string areaClaimValue)
        {
            throw new NotImplementedException();
        }

        public static string GetCountryCode(string countryClaimValue)
        {
            throw new NotImplementedException();
        }
    }
}