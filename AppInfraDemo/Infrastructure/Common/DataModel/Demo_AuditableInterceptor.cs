using System;
using System.Linq;
using System.Security.Claims;
using Common.DataModel.Abstractions;
using iQuarc.AppBoot;
using iQuarc.DataAccess;

namespace Common.DataModel
{
    [Service("AuditableInterceptor", typeof(IEntityInterceptor))]
    public sealed class AuditableInterceptor : GlobalEntityInterceptor<IAuditable>
    {
        public override void OnSave(IEntityEntry<IAuditable> entry, IUnitOfWork repository)
        {
            var systemDate = DateTime.Now;

            var claimsIdentity = ClaimsPrincipal.Current.Identities.OfType<ClaimsIdentity>().FirstOrDefault();
            string userName = claimsIdentity != null ? claimsIdentity.Name : ClaimsPrincipal.Current.Identities.First().Name;

            if (entry.State == EntityEntryState.Added)
            {
                entry.Entity.CreationDate = systemDate;
                entry.Entity.CreatedBy = userName;
            }

            entry.Entity.LastEditDate = systemDate;
            entry.Entity.LastEditBy = userName;
        }

        public override void OnLoad(IEntityEntry<IAuditable> entry, IRepository repository)
        {
            throw new NotImplementedException();
        }

        public override void OnDelete(IEntityEntry<IAuditable> entry, IUnitOfWork repository)
        {
            throw new NotImplementedException();
        }
    }
}