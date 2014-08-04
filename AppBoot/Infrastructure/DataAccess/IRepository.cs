using System.Linq;

namespace DataAccess
{
    public interface IRepository
    {
        IQueryable<T> GetEntities<T>() where T : class;
        IUnitOfWork CreateUnitOfWork();
    }
}