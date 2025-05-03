using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.Data
{
    [Table("ProductCharacteristics")]
    public class ProductCharacteristic
    {
        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public Guid CharacteristicId { get; set; }

        [MaxLength(500)]
        public string? Value { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [ForeignKey("CharacteristicId")]
        public Characteristic Characteristic { get; set; }
    }
}