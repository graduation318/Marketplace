using AutoMapper;
using Marketplace.Data;
using Marketplace.Data.Models;
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

    public async Task<string> ProcessShipmentAsync(Guid orderId)
    {
        var request = new ShipmentRequest
        {
            OrderId = orderId,
            ShippingStatus = "Processing",
            Carrier = "UPS",
            TrackingNumber = Guid.NewGuid().ToString().Substring(0, 10),
            EstimatedDeliveryDate = DateTime.UtcNow.AddDays(5)
        };

        return await _provider.CreateShipmentAsync(request);
    }

    public async Task<string> GetShipmentStatusAsync(Guid orderId)
    {
        var shipment = await _provider.FindByOrderIdAsync(orderId);
        if (shipment == null)
            return "Shipment not found";

        return await _provider.GetTrackingStatusAsync(shipment.TrackingNumber);
    }
}