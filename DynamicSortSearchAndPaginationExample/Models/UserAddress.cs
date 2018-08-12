using System.ComponentModel.DataAnnotations.Schema;

namespace DynamicFilterAndPaginationExample.Models
{
    [Table("UserAddress", Schema = "users")]
    public class UserAddress
    {
        public int Id { get; set; }
        [ForeignKey("AddressId")]
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
