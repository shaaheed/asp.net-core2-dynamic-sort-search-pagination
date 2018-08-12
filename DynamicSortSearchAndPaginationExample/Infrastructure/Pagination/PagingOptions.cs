namespace DynamicFilterAndPaginationExample.Infrastructure
{
    public class PagingOptions : IPagingOptions
    {
        public int? Offset { get; set; }
        public int? Limit { get; set; }
    }
}
