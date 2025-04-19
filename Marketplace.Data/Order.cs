namespace Marketplace.Data
{
    public class Order : BaseModel
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Pending";
        public decimal TotalCost { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public string ShippingAddress { get; set; } = string.Empty;
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public Payment Payment { get; set; }
        public Shipment Shipment { get; set; }
    }
}