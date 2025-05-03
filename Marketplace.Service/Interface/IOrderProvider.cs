using Marketplace.Data;

namespace Marketplace.Service.Interface
{
    public interface IOrderProvider : IBaseProvider<Order>
    {
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);
        Task<Order?> FindByIdWithDetailsAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<Order>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken);
    }
}