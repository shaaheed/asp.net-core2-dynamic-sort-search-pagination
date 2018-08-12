using System;

namespace DynamicFilterAndPaginationExample.Infrastructure
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class SortableAttribute : Attribute
    {
    }
}
