using System.Diagnostics.CodeAnalysis;
using PersonalFinance.Common.Enums;
using System.Linq;
using System.Linq.Expressions;

namespace PersonalFinance.Infraestructure.DataAcces.Pagination
{
    public static class ExtensionsOrderBy
    {
        public static IQueryable<T> OrderByPropertyOrField<T>(this IQueryable<T> queryable, string propertyOrFieldName, bool ascending = true)
        {
            var elementType = typeof(T);
            var orderByMethodName = ascending
                ? GenericEnumerator.OrderByMethod.OrderBy.ToString()
                : GenericEnumerator.OrderByMethod.OrderByDescending.ToString();

            var parameterExpression = Expression.Parameter(elementType);
            var propertyOrFieldExpression = Expression.PropertyOrField(parameterExpression, propertyOrFieldName);
            var selector = Expression.Lambda(propertyOrFieldExpression, parameterExpression);

            var orderByExpression = Expression.Call(typeof(Queryable), orderByMethodName, new[] { elementType, propertyOrFieldExpression.Type }, queryable.Expression, selector);

            return queryable.Provider.CreateQuery<T>(orderByExpression);
        }
    }
}
