using System.Security.Claims;
using iQuarc.DataAccess;

namespace SeparatedDbs.DataAccess
{
public class MultitenancyDbContextFactory : IDbContextFactory
{
    public IDbContextWrapper CreateContext()
    {
        string tenantKey = GetTenantKeyFromCurrentUser();
        string connectionName = $"{tenantKey}_PhysioDb";
        return new DbContextWrapper(new PhysioEntities(connectionName));
    }

    private string GetTenantKeyFromCurrentUser()
    {
        const string tenantKeyClaim = "tenant_key";
        Claim tenantClaim = ClaimsPrincipal.Current.FindFirst(tenantKeyClaim);
        return tenantClaim.Value;
    }
}

    //TODO: generate this w/ EF
}
