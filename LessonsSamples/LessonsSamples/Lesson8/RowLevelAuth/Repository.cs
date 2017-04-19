using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LessonsSamples.Lesson3.DataModel;

namespace LessonsSamples.Lesson8.RowLevelAuth
{
    public class Repository : IRepository
    {
        private IRepository inner;
        private IRowAuthPoliciesContainer container;

        public IQueryable<T> GetEntities<T>() where T : class
        {
            IQueryable<T> set = inner.GetEntities<T>();

            Expression<Func<T, bool>> authFilter = BuildWhereExpression<T>();

            return set.Where(authFilter);
        }

        private Expression<Func<T, bool>> BuildWhereExpression<T>()
        {
            if (container.HasPolicy<T>())
            {
                IRowAuthPolicy<T> policy = container.GetPolicy<T>();
                return policy.BuildAuthFilterExpression();
            }
            else
            {
                Expression<Func<T, bool>> trueExpression = entity => true;
                return trueExpression;
            }
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public IUnitOfWork CreateUnitOfWork()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
