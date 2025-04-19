using AutoMapper;
using Marketplace.Data;
using Marketplace.Service.Interface;
using Marketplace.Service.ModelsRequest;

namespace Marketplace.Service;

public class ShipmentService : BaseService<Shipment, ShipmentRequest, IShipmentProvider>, IShipmentService
{
    private readonly IShipmentProvider _provider;
    private readonly IMapper _mapper;

    public ShipmentService(IShipmentProvider provider, IMapper mapper) : base(provider, mapper)
    {
        _provider = provider;
        _mapper = mapper;
    }
}