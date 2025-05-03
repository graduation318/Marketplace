using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.Data
{
    [Table("Products")]
    public class Product : BaseModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Column("Category_Id")]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; } = string.Empty;
        [MaxLength(100)]
        public string Brand { get; set; } = string.Empty;
        [MaxLength(100)]
        public string Model { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        [MaxLength(200)]
        public string ImageUrl { get; set; } = string.Empty;
        public List<ProductCharacteristic> Characteristics { get; set; } = new List<ProductCharacteristic>();
        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}