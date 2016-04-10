using System.Data.Entity;

namespace DataAccess
{
	public interface IDbContextFactory
	{
		DbContext CreateContext();
	}
}