using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.Data
{
    [Table("Characteristics")]
    public class Characteristic : BaseModel // Id из BaseModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public List<ProductCharacteristic> ProductCharacteristics { get; set; } = new();
    }
}