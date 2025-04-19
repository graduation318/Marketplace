using Marketplace.Data;
using Marketplace.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infrastructure.Providers;

public class ProductProvider : IProductProvider
{
    private readonly ApplicationContext _applicationContext;

    public ProductProvider(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public async Task<Guid> AddAsync(Product entity, CancellationToken cancellationToken)
    {
        _applicationContext.Add(entity);
        await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return entity.Id;
    }

    public async Task<Product?> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _applicationContext.Products
            .Include(p => p.Category)
            .Include(p => p.Characteristics)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var product = await FindAsync(id, cancellationToken);
        ArgumentNullException.ThrowIfNull(product);
        _applicationContext.Remove(product);
        await _applicationContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Product> UpdateAsync(Product entity, CancellationToken cancellationToken)
    {
        _applicationContext.Update(entity);
        await _applicationContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<List<Product>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _applicationContext.Products
            .Include(p => p.Category)
            .Include(p => p.Characteristics)
            .ToListAsync(cancellationToken: cancellationToken);
    }
}