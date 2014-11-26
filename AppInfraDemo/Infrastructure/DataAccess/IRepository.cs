using System.Linq;

namespace DataAccess
{
    public interface IRepository
    {
        IQueryable<TDbEntity> GetEntities<TDbEntity>() where TDbEntity : class;
        IUnitOfWork CreateUnitOfWork();
    }
}