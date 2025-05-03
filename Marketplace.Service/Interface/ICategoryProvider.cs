using Marketplace.Data;

namespace Marketplace.Service.Interface
{
    public interface ICategoryProvider : IBaseProvider<Category>
    {
        Task<Category?> GetByNameAsync(string name, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);

    }
}