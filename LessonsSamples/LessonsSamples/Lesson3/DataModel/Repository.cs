using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using iQuarc.AppBoot;
using LessonsSamples.ItCamp;

namespace LessonsSamples.Lesson3.DataModel
{
    public interface IRepository : IDisposable
    {
        IQueryable<T> GetEntities<T>();
        void SaveChanges();
        IUnitOfWork CreateUnitOfWork();
    }

    class OrderingService
    {
        public void ModifyOrder(int id, decimal totalDue)
        {
            using (IRepository repository = CreateUnitOfWork())
            {
                SalesOrderHeader order = repository
                    .GetEntities<SalesOrderHeader>().FirstOrDefault(o => o.Id == id);

                order.TotalDue = totalDue;
                order.TaxAmt = CalculateTax(order);

                repository.SaveChanges();
            }
        }

        private decimal CalculateTax(SalesOrderHeader order)
        {
            throw new NotImplementedException();
        }

        private IRepository CreateUnitOfWork()
        {
            throw new NotImplementedException();
        }
    }

    class OrderRepository : Repository
    {
        bool IsValidForSave(SalesOrderHeader order)
        {
            if (order.TotalDue > order.SubTotal)
                return false;

            return true;
        }
    }

    [Service(typeof(IRepository))]
    class Repository : IRepository
    {
        private DbContext context;
        private bool trackEntities;
        private object cultureProvider;

        public IQueryable<T> GetEntities<T>()
        {
            IQueryable<T> entities = GetEntitiesInternal<T>();
            
            IQueryable<T> filtered =  FilterByBrand(entities);

            return filtered;
        }

        private IQueryable<T> GetEntitiesInternal<T>()
        {
            System.Data.Entity.DbSet<T> set = context.Set<T>();
            IQueryable<T> queryableSet = !trackEntities ? set.AsNoTracking() : set;

            return new DataLocalizationQueryable<T>(queryableSet);
            
        }

        private IQueryable<T> FilterByBrand<T>(IQueryable<T> entities)
        {
            int brandLabelId  = ClaimsPrincipal.Current.GetClaimValue<int>(Claims.BrandLabelId);
            Expression<Func<T, int?>> selector = SelectBrandIdFrom(entities);

            var condition = ExpressionBuilder.BuildWhereExpression(selector, brandLabelId, ExpressionType.Equal);

            return entities.Where(condition);
        }

        private Expression<Func<T, int?>> SelectBrandIdFrom<T>(IQueryable<T> entities)
        {
            throw new NotImplementedException();
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public IUnitOfWork CreateUnitOfWork()
        {
            throw new NotImplementedException();
        }
    }

    class DataLocalizationQueryable<T> : IOrderedQueryable<T>
    {
        private DataLocalizationExpressionVisitor translationVisitor;
        private IQueryable<T> internalQuery;

        public DataLocalizationQueryable(IQueryable<T> query)
        {
            internalQuery = query;
            this.translationVisitor = new DataLocalizationExpressionVisitor();
            this.Provider = new DataLocalizationQueryProvider(query.Provider, this.translationVisitor);
            this.ElementType = typeof(T);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return internalQuery.Provider.CreateQuery<T>(translationVisitor.Visit(internalQuery.Expression)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Expression Expression { get; private set; }
        public Type ElementType { get; private set; }
        public IQueryProvider Provider { get; private set; }
    }

    internal class DataLocalizationQueryProvider : IQueryProvider
    {
        public DataLocalizationQueryProvider(object provider, DataLocalizationExpressionVisitor translationVisitor)
        {
            throw new NotImplementedException();
        }
    }

    internal class DataLocalizationExpressionVisitor
    {
        public DataLocalizationExpressionVisitor(object getCurrentUiCulture)
        {
            throw new NotImplementedException();
        }

        public DataLocalizationExpressionVisitor()
        {
            throw new NotImplementedException();
        }

        public Expression Visit(Expression expression)
        {
            throw new NotImplementedException();
        }
    }

    public sealed class BrandFilterRegister
    {
        private static object register;

        public static void Configure()
        {
            register
                .Register<Hotel>(x => x.BrandLabelId)
                .Register<RecreationArea>(x => x.Hotel.BrandLabelId)
                ;
        }
    }

    internal class Hotel
    {
    }

    internal class Supplier
    {
    }

    internal class BrandManager
    {
    }

    internal static class ExpressionBuilder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        public static Expression<Func<TSource, bool>> BuildWhereExpression<TSource, TProperty, TValue>(Expression<Func<TSource, TProperty>> imageIdSelector, TValue value, ExpressionType expressionType)
        {
            Expression<Func<TValue>> imageIdExpression = () => value; // Create a closure over imageId parameter so it will be lifted into a <>DisplayClass field in order to use the field in the lambda expression
            var whereExpression = Expression.Lambda<Func<TSource, bool>>(Expression.MakeBinary(expressionType, Expression.Convert(imageIdSelector.Body, typeof(TValue)), imageIdExpression.Body), imageIdSelector.Parameters);
            return whereExpression;
        }
    }

    internal class Claims
    {
        public static string BrandLabelId { get; set; }
    }

    public static class ClaimsExtensions
    {
        public static void AddClaim<T>(this ClaimsIdentity identity, string claimType, T value)
        {
            if (identity == null)
                throw new ArgumentNullException("identity");

            identity.AddClaim(new Claim(claimType, Convert.ToString(value, CultureInfo.InvariantCulture), typeof(T).Name));
        }

        public static T GetClaimValue<T>(this ClaimsPrincipal principal, string claimType)
        {
            if (principal == null)
                throw new ArgumentNullException("principal");

            var claim = principal.Claims.First(c => c.Type == claimType);

            if (!string.IsNullOrEmpty(claim.ValueType) && !typeof(T).Name.Equals(claim.ValueType))
                throw new InvalidCastException("Failed to cast claim type " + claim.ValueType + " to type " + typeof(T).Name);

            return (T)Convert.ChangeType(claim.Value, typeof(T), CultureInfo.InvariantCulture);
        }

        public static string[] GetRoles(this ClaimsPrincipal principal)
        {
            return principal.Claims.Where(c => c.Type == ClaimTypes.Role).Select(cv => cv.Value).ToArray();
        }

    

    }
}
