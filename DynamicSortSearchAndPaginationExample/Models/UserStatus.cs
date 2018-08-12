using System.ComponentModel.DataAnnotations.Schema;

namespace DynamicFilterAndPaginationExample.Models
{
    [Table("UserStatus", Schema = "users")]
    public class UserStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }
    }
}
