using Marketplace.Data;
using Marketplace.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infrastructure.Providers;

public class ProductCharacteristicProvider : IProductCharacteristicProvider
{
    private readonly ApplicationContext _applicationContext;

    public ProductCharacteristicProvider(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public async Task<Guid> AddAsync(ProductCharacteristic entity, CancellationToken cancellationToken)
    {
        _applicationContext.Add(entity);
        await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return entity.Id;
    }

    public async Task<ProductCharacteristic?> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _applicationContext.ProductCharacteristics
            .Include(pc => pc.Product)
            .Include(pc => pc.Characteristic)
            .FirstOrDefaultAsync(pc => pc.Id == id, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var characteristic = await FindAsync(id, cancellationToken);
        ArgumentNullException.ThrowIfNull(characteristic);
        _applicationContext.Remove(characteristic);
        await _applicationContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<ProductCharacteristic> UpdateAsync(ProductCharacteristic entity, CancellationToken cancellationToken)
    {
        _applicationContext.Update(entity);
        await _applicationContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<List<ProductCharacteristic>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _applicationContext.ProductCharacteristics
            .Include(pc => pc.Product)
            .Include(pc => pc.Characteristic)
            .ToListAsync(cancellationToken: cancellationToken);
    }
}