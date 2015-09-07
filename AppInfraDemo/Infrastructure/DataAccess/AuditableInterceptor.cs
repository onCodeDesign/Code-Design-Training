using System;
using System.Linq;
using System.Security.Claims;
using iQuarc.AppBoot;

namespace DataAccess
{
    [Service("AuditableInterceptor", typeof(IEntityInterceptor))]
    public sealed class AuditableInterceptor : GlobalEntityInterceptor<IAuditable>
    {

        public override void OnLoad(IEntityEntryFacade<IAuditable> entity, IRepository repository)
        {
        }

        public override void OnSave(IEntityEntryFacade<IAuditable> entity, IRepository repository)
        {
            var systemDate = DateTime.Now;

            var claimsIdentity = ClaimsPrincipal.Current.Identities.OfType<ClaimsIdentity>().FirstOrDefault();
            string userName = claimsIdentity != null ? claimsIdentity.Name : ClaimsPrincipal.Current.Identities.First().Name;

            if (entity.State == EntityEntryStates.Added)
            {
                entity.Entity.CreationDate = systemDate;
                entity.Entity.CreatedBy = userName;
            }

            entity.Entity.LastEditDate = systemDate;
            entity.Entity.LastEditBy = userName;
        }

        public override void OnEntityRemoved(IEntityEntryFacade<IAuditable> entity, IRepository repository)
        {
        }
    }
}