using Marketplace.Data;

namespace Marketplace.Service.Interface
{
    public interface IShipmentService
    {
        Task<string> ProcessShipmentAsync(Guid orderId);

        Task<string> GetShipmentStatusAsync(Guid orderId);
    }
}