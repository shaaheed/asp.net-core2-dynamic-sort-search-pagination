using DynamicFilterAndPaginationExample.Infrastructure;
using DynamicFilterAndPaginationExample.Infrastructure.Search;
using System.ComponentModel.DataAnnotations.Schema;

namespace DynamicFilterAndPaginationExample.Models
{
    [Table("User", Schema = "users")]
    public class User
    {
        [Sortable]
        [Searchable(Type = SearchableType.Int32)]
        public int Id { get; set; }
        [Sortable]
        [Searchable(Type = SearchableType.String)]
        public string Name { get; set; }
        [Sortable]
        public string Email { get; set; }
        [ForeignKey("UserStatusId")]
        public int  UserStatusId { get; set; }
        public UserStatus UserStatus { get; set; }
    }
}
