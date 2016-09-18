using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LinqDyn
{
    internal class FilterExpressions
    {
        internal static Expression<Func<TSource, bool>> TextContainsFilter<TSource>(PropertyInfo prop, object val)
        {
            if (val == null || String.IsNullOrEmpty((string)val)) { return (x) => true; }
            var sourceType = typeof(TSource);
            var parameter = Expression.Parameter(sourceType, "p");
            var propertyRef = Expression.Property(parameter, prop.Name); // x => x.PropertyName
            var containsMethod = typeof(string).GetMethod("Contains", new Type[] { typeof(string) });
            var containsParamVal = Expression.Constant((string)val);
            var body = Expression.Call(propertyRef, containsMethod, containsParamVal); // x.PropertyName.Contains(val)
            return Expression.Lambda<Func<TSource, bool>>(body, parameter);
        }
        internal static Expression<Func<TSource, bool>> EqualityFilter<TSource>(PropertyInfo prop, object val)
        {
            var sourceType = typeof(TSource);
            var parameter = Expression.Parameter(sourceType, "p");
            var propertyRef = Expression.Property(parameter, prop.Name); // x => x.PropertyName
            var equalityParam = Expression.Constant(val);
            Expression eq = Expression.Equal(propertyRef, equalityParam);
            return Expression.Lambda<Func<TSource, bool>>(eq, parameter);
        }
        internal static Expression<Func<TSource, bool>> GreaterOrEqualFilter<TSource>(PropertyInfo prop, object val)
        {
            var sourceType = typeof(TSource);
            var parameter = Expression.Parameter(sourceType, "p");
            var propertyRef = Expression.Property(parameter, prop.Name); // x => x.PropertyName
            var compareParam = Expression.Constant(val);
            Expression compare = Expression.GreaterThanOrEqual(propertyRef, compareParam);
            return Expression.Lambda<Func<TSource, bool>>(compare, parameter);
        }
        internal static Expression<Func<TSource, bool>> LessOrEqualFilter<TSource>(PropertyInfo prop, object val)
        {
            var sourceType = typeof(TSource);
            var parameter = Expression.Parameter(sourceType, "p");
            var propertyRef = Expression.Property(parameter, prop.Name); // x => x.PropertyName
            var compareParam = Expression.Constant(val);
            Expression compare = Expression.LessThanOrEqual(propertyRef, compareParam);
            return Expression.Lambda<Func<TSource, bool>>(compare, parameter);
        }
    }
}
