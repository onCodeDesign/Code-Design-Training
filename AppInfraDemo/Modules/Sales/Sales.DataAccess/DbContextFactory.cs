using iQuarc.AppBoot;
using iQuarc.DataAccess;

namespace Sales.DataAccess
{
	[Service(typeof(IDbContextFactory))]
	public class DbContextFactory : DbContextFactory<SalesEntities>
    {
    }
}
