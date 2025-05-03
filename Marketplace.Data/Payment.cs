using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.Data
{
    [Table("Payments")]
    public class Payment : BaseModel
    {
        [ForeignKey("Order")]
        [Column("Order_Id")]
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
        [MaxLength(100)]
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        [MaxLength(50)]
        public string Status { get; set; } = "Pending";
    }
}