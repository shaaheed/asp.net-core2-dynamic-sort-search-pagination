using DynamicFilterAndPaginationExample.Infrastructure.Search;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace DynamicFilterAndPaginationExample.Infrastructure
{
    public static class SearchExtensions
    {
        public static IQueryable<T> ApplySearch<T>(this IQueryable<T> query, ISearchOptions options)
        {
            if (options?.Search?.Length > 0)
            {
                var _searchQuery = options.Search;
                var searchQueryLength = _searchQuery.Length;

                // get given type's all properties
                var properties = typeof(T).GetProperties();
                var propertiesLength = properties.Length;

                // iterate over all terms
                for (int i = 0; i < searchQueryLength; i++)
                {

                    if (string.IsNullOrEmpty(_searchQuery[i])) continue;

                    // expression -> name eq shahid
                    var tokens = _searchQuery[i].Split(' ');
                    if (tokens.Length == 3)
                    {
                        string @operator = tokens[1];
                        string value = tokens[2];

                        for (int j = 0; j < propertiesLength; j++)
                        {
                            // if property has sortable attribute and sort term equals to property name
                            var searchableAttribute = properties[j].GetCustomAttributes<SearchableAttribute>().FirstOrDefault();
                            bool isSearchable = searchableAttribute != null && properties[j].Name.Equals(tokens[0], StringComparison.OrdinalIgnoreCase);

                            if (isSearchable)
                            {
                                // build up the LINQ expression backwards:
                                // query = query.Where(x => x.Property == "Value");

                                var parameter = ExpressionHelper.Parameter<T>();

                                // x.Property
                                var left = ExpressionHelper.GetPropertyExpression(parameter, properties[j]);

                                // "Value"
                                var right = GetConstantExpression(tokens[2], searchableAttribute.Type);

                                // x.Property == "Value"
                                var comparisonExpression = GetComparisonExpression(left, tokens[1], right);

                                // x => x.Property == "Value"
                                var lambda = ExpressionHelper
                                    .GetLambda<T, bool>(parameter, comparisonExpression);

                                // query = query.Where...
                                query = ExpressionHelper.CallWhere(query, lambda);

                            }
                        }
                    }
                }
            }
            return query;
        }

        private static Expression GetComparisonExpression(MemberExpression left, string opt, ConstantExpression right)
        {
            switch (opt.ToLower())
            {
                case "eq": return Expression.Equal(left, right);
                case "gt": return Expression.GreaterThan(left, right);
                case "gte": return Expression.GreaterThanOrEqual(left, right);
                case "lt": return Expression.LessThan(left, right);
                case "lte": return Expression.LessThanOrEqual(left, right);
                default: return Expression.Equal(left, right);
            }
        }

        private static ConstantExpression GetConstantExpression(string value, SearchableType type = SearchableType.String)
        {
            switch (type)
            {
                case SearchableType.String:
                    return Expression.Constant(value);
                case SearchableType.Int32:
                    return Expression.Constant(int.Parse(value));
                case SearchableType.Boolen:
                    return Expression.Constant(bool.Parse(value));
                default:
                    return Expression.Constant(value);
            }
        }

    }
}
