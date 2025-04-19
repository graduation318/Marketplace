using AutoMapper;
using Marketplace.Data;
using Marketplace.Service.Interface;
using Marketplace.Service.ModelsRequest;

namespace Marketplace.Service;

public class OrderService : BaseService<Order, OrderRequest, IOrderProvider>, IOrderService
{
    private readonly IOrderProvider _provider;
    private readonly IMapper _mapper;

    public OrderService(IOrderProvider provider, IMapper mapper) : base(provider, mapper)
    {
        _provider = provider;
        _mapper = mapper;
    }
}