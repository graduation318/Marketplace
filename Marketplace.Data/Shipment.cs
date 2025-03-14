namespace Shop.Data
{
    public class Shipment
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public string TrackingNumber { get; set; } = string.Empty;
        public string Carrier { get; set; } = string.Empty;
        public string ShippingStatus { get; set; } = "Pending";
        public DateTime? EstimatedDeliveryDate { get; set; }
    }
}