using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.Data
{
    [Table("Shipments")]
    public class Shipment : BaseModel
    {
        [ForeignKey("Order")]
        [Column("Order_Id")]
        [Required]
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        [MaxLength(100)]
        public string TrackingNumber { get; set; } = string.Empty;
        [MaxLength(100)]
        public string Carrier { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string ShippingStatus { get; set; } = "Pending";
        public DateTime? EstimatedDeliveryDate { get; set; }
    }
}