using System.ComponentModel.DataAnnotations;

namespace Marketplace.Service.ModelsRequest
{
    public class PaymentRequest
    {
        public Guid OrderId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending";
    }
}