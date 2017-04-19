using System;
using System.Linq.Expressions;

namespace LessonsSamples.Lesson8.RowLevelAuth
{
    class RowAuthPolicy<TEntity, TProperty> : IRowAuthPolicy<TEntity>
    {
        private readonly Expression<Func<TEntity, TProperty>> selector;
        private Func<TProperty> filterValueGetter;
        private readonly IRowAuthPoliciesContainer parent;


        public RowAuthPolicy(Expression<Func<TEntity, TProperty>> selector, IRowAuthPoliciesContainer parent)
        {
            this.selector = selector;
            this.parent = parent;
            filterValueGetter = () => default(TProperty);
            EntityType = typeof(TEntity);
        }

        public Type EntityType { get; }

        public Expression<Func<TEntity, bool>> BuildAuthFilterExpression()
        {
            if (shouldApplyFunc.Invoke())
                return BuildFilerExpression();

            return entity => true;
        }

        private Expression<Func<TEntity, bool>> BuildFilerExpression()
        {
            TProperty value = filterValueGetter.Invoke();
            Expression<Func<TProperty>> filterValueParam = () => value;

            var filterExpression = Expression.Lambda<Func<TEntity, bool>>(
                Expression.MakeBinary(ExpressionType.Equal,
                    Expression.Convert(selector.Body, typeof(TProperty)),
                    filterValueParam.Body),
                selector.Parameters);

            return filterExpression;
        }

        public IRowAuthPoliciesContainer Match(Func<TProperty> filterValueGetFunc)
        {
            filterValueGetter = filterValueGetFunc;
            return parent;
        }

        private Func<bool> shouldApplyFunc;

        public RowAuthPolicy<TEntity, TProperty> When(Func<bool> condition)
        {
            shouldApplyFunc = condition;
            return this;
        }
    }

    public interface IRowAuthPolicy<TEntity>
    {
        Type EntityType { get; }
        Expression<Func<TEntity, bool>> BuildAuthFilterExpression();
    }
}