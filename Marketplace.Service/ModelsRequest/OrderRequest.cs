using System;
using System.ComponentModel.DataAnnotations;

namespace Marketplace.Service.ModelsRequest
{
    public class OrderRequest
    {
        public Guid UserId { get; set; }
        public string Status { get; set; } = "Pending";
        public decimal TotalCost { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public string ShippingAddress { get; set; } = string.Empty;
    }
}