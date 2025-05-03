using AutoMapper;
using Marketplace.Data;
using Marketplace.Service.Interface;
using Marketplace.Service.ModelsRequest;

namespace Marketplace.Service;

public class PaymentService : BaseService<Payment, PaymentRequest, IPaymentProvider>, IPaymentService
{
    private readonly IPaymentProvider _provider;
    private readonly IMapper _mapper;

    public PaymentService(IPaymentProvider provider, IMapper mapper) : base(provider, mapper)
    {
        _provider = provider;
        _mapper = mapper;
    }

    public async Task<Payment?> GetByOrderIdAsync(Guid orderId, CancellationToken cancellationToken)
    {
        return await _provider.FindByOrderIdAsync(orderId, cancellationToken);
    }

    public async Task<string> ProcessPaymentAsync(Guid orderId, decimal amount, string method, CancellationToken cancellationToken)
    {
        var request = new PaymentRequest
        {
            OrderId = orderId,
            Amount = amount,
            PaymentMethod = method
        };

        return await _provider.CreatePaymentAsync(request, cancellationToken);
    }
}