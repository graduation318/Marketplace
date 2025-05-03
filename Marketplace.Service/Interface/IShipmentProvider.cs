using Marketplace.Data;
using Marketplace.Data.Models;

namespace Marketplace.Service.Interface
{
    public interface IShipmentProvider : IBaseProvider<Shipment>
    {
        Task<string> CreateShipmentAsync(ShipmentRequest request);
        Task<string> GetTrackingStatusAsync(string trackingNumber);
        Task<Shipment?> FindByOrderIdAsync(Guid orderId);

    }
}