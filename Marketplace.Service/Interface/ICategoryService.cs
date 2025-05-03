using Marketplace.Data;
using Marketplace.Service.ModelsRequest;

namespace Marketplace.Service.Interface
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken);
        Task<Category?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Category?> GetByNameAsync(string name, CancellationToken cancellationToken);
        Task<Category> CreateAsync(CategoryRequest request, CancellationToken cancellationToken);
        Task<Category> UpdateAsync(Guid id, CategoryRequest request, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}