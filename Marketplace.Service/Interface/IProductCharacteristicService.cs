using Marketplace.Data;
using Marketplace.Service.ModelsRequest;

namespace Marketplace.Service.Interface;

public interface IProductCharacteristicService : IBaseService<ProductCharacteristic, ProductCharacteristicRequest>
{
    Task<List<ProductCharacteristic>> GetByProductIdAsync(Guid productId, CancellationToken cancellationToken);
    Task<List<ProductCharacteristic>> GetByCharacteristicIdAsync(Guid characteristicId, CancellationToken cancellationToken);
}
