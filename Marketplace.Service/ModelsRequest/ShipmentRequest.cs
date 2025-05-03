namespace Marketplace.Data.Models
{
    public class ShipmentRequest
    {
        public Guid OrderId { get; set; }

        public string Address { get; set; }

        public string RecipientName { get; set; }

        public string RecipientPhone { get; set; }

        public string Carrier { get; set; }

        public decimal Weight { get; set; }

        public DateTime RequestedDate { get; set; } = DateTime.UtcNow;
        public string ShippingStatus { get; set; }
        public string TrackingNumber { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
    }
}