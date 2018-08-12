using System.ComponentModel.DataAnnotations.Schema;

namespace DynamicFilterAndPaginationExample.Models
{
    [Table("AddressType", Schema = "address")]
    public class AddressType
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }
}
