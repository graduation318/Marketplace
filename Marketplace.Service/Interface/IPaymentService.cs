using Marketplace.Data;

namespace Marketplace.Service.Interface
{
    public interface IPaymentService
    {
        Task<Payment?> GetByOrderIdAsync(Guid orderId, CancellationToken cancellationToken);
        Task<string> ProcessPaymentAsync(Guid orderId, decimal amount, string method, CancellationToken cancellationToken);
    }
}