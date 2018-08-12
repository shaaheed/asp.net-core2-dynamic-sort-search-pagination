using System.Linq;

namespace DynamicFilterAndPaginationExample.Infrastructure
{
    public static class PaginationExtensions
    {
        public static IQueryable<T> ApplyPagination<T>(this IQueryable<T> query, IPagingOptions options)
        {
            if (options != null)
            {
                options.Offset = options.Offset ?? 0;
                options.Limit = options.Limit ?? 20;
                query = query.Skip(options.Offset.Value).Take(options.Limit.Value);
            }
            return query;
        }
    }
}
