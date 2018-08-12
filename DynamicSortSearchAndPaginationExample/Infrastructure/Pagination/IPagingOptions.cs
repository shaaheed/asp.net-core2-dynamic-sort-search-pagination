namespace DynamicFilterAndPaginationExample.Infrastructure
{
    public interface IPagingOptions
    {
        int? Offset { get; set; }
        int? Limit { get; set; }
    }
}
