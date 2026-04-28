
using System.Linq.Expressions;

namespace Apllication.Common;
public static class FilterTools<T>
{

    public static (IQueryable<T>, int TotalCount) ApplySortAndPagination(IQueryable<T> query, PaginationParam paginationParam)
    {
        int count = query.Count();
        if (!string.IsNullOrEmpty(paginationParam.OrderBy)) query = ApplySorting(query, paginationParam.OrderBy, paginationParam.OrderDescending);

        return (query.Skip((paginationParam.PageNumber - 1) * paginationParam.PageSize).Take(paginationParam.PageSize), count);
    }
    private static IQueryable<T> ApplySorting(IQueryable<T> query, string orderBy, bool descending)
    {
        if (string.IsNullOrWhiteSpace(orderBy))
            return query;

        var parameter = Expression.Parameter(typeof(T), "x");
        var property = GetPropertyExpression(parameter, orderBy);
        if (property == null)
            return query;

        var lambda = Expression.Lambda(property, parameter);

        string methodName = descending ? "OrderByDescending" : "OrderBy";
        var resultExpression = Expression.Call(typeof(Queryable), methodName, new Type[] { typeof(T), property.Type },
            query.Expression, Expression.Quote(lambda));

        return query.Provider.CreateQuery<T>(resultExpression);
    }
    private static Expression? GetPropertyExpression(Expression parameter, string propertyName)
    {
        try
        {
            string[] parts = propertyName.Split('.');
            Expression property = parameter;
            foreach (var part in parts)
            {
                property = Expression.Property(property, part);
            }
            return property;
        }
        catch
        {
            return null;
        }
    }
    private static (IQueryable<T>, int) Paging(IQueryable<T> query, PaginationParam paginationParam)
    {
        return FilterTools<T>.ApplySortAndPagination(query, paginationParam);
    }

}
