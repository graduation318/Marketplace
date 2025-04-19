using Marketplace.Data;
using Marketplace.Service.ModelsRequest;

namespace Marketplace.Service.Interface;

public interface IProductService : IBaseService<Product, ProductRequest>
{
    Task<List<Product>> GetByTitleAsync(string title, CancellationToken cancellationToken);
}