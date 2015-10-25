using System;
using System.Linq.Expressions;

namespace LessonsSamples.Lesson8.Validation
{
	interface IValidationRulesSet<T>
	{
		IValidationRulesSet<T> Required(Expression<Func<T, object>> property);
		IValidationRulesSet<T> Required(Expression<Func<T, object>> property, string messageKey);

		IValidationRulesSet<T> DefineNewState(Func<T, bool> state);
		IValidationRulesSet<T> RegularExpression(Expression<Func<T, object>> property, string postCodeRegex);
	}
}