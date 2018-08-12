using DynamicFilterAndPaginationExample.Infrastructure.Search;
using System;

namespace DynamicFilterAndPaginationExample.Infrastructure
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class SearchableAttribute : Attribute
    {
        public SearchableType Type { get; set; }
    }
}
