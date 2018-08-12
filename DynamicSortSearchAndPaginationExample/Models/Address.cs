using System.ComponentModel.DataAnnotations.Schema;

namespace DynamicFilterAndPaginationExample.Models
{
    [Table("Address", Schema = "address")]
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        [ForeignKey("AddressTypeId")]
        public int AddressTypeId { get; set; }
        public AddressType AddressType { get; set; }
    }
}
