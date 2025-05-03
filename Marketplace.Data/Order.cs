using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.Data
{
    [Table("Orders")]
    public class Order : BaseModel
    {
        [Required]
        [ForeignKey("User")]
        [Column("User_Id")]
        public Guid UserId { get; set; }
        public User User { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        [Required]
        [MaxLength(50)]
        public string Status { get; set; } = "Pending";
        public decimal TotalCost { get; set; }
        [Required]
        [MaxLength(100)]
        public string PaymentMethod { get; set; } = string.Empty;
        [Required]
        [MaxLength(300)]
        public string ShippingAddress { get; set; } = string.Empty;
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public Payment Payment { get; set; }
        public Shipment Shipment { get; set; }
    }
}