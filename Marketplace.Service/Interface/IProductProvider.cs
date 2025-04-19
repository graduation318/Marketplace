using Marketplace.Data;

namespace Marketplace.Service.Interface;

public interface IProductProvider : IBaseProvider<Product>
{
    Task<List<Product>> GetByTitleAsync(string title, CancellationToken cancellationToken);
}