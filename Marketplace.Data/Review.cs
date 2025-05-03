using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.Data
{
    [Table("Reviews")]
    public class Review
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Product")]
        [Column("Product_Id")]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        [ForeignKey("Characteristic")]
        [Column("Characteristic_Id")]
        public Guid CharacteristicId { get; set; }
        public Characteristic Characteristic { get; set; }
    }
}