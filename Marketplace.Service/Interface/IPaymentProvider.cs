using Marketplace.Data;
using Marketplace.Service.ModelsRequest;

namespace Marketplace.Service.Interface
{
    public interface IPaymentProvider : IBaseProvider<Payment>
    {
        Task<Payment?> FindByOrderIdAsync(Guid orderId, CancellationToken cancellationToken);
        Task<string> CreatePaymentAsync(PaymentRequest request, CancellationToken cancellationToken);
    }
}