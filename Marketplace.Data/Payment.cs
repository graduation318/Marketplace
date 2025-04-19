namespace Marketplace.Data
{
    public class Payment : BaseModel
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending";
    }
}