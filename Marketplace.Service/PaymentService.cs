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
}