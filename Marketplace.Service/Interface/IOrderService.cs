using Marketplace.Data;
using Marketplace.Service.ModelsRequest;

namespace Marketplace.Service.Interface
{
    public interface IOrderService
    {
        Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<Order>> GetAllAsync(CancellationToken cancellationToken);
        Task<IEnumerable<Order>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken);
        Task<Order> CreateAsync(OrderRequest request, CancellationToken cancellationToken);
        Task<Order> UpdateAsync(Guid id, OrderRequest request, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}