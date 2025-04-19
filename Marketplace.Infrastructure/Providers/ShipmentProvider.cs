using Marketplace.Data;
using Marketplace.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infrastructure.Providers;

public class ShipmentSlotProvider : IShipmentSlotProvider
{
    private readonly ApplicationContext _applicationContext;

    public ShipmentSlotProvider(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public async Task<Guid> AddAsync(ShipmentSlot entity, CancellationToken cancellationToken)
    {
        _applicationContext.Add(entity);
        await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return entity.Id;
    }

    public async Task<ShipmentSlot?> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _applicationContext.ShipmentSlots
            .Include(s => s.Order)
            .Include(s => s.Courier)
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var slot = await FindAsync(id, cancellationToken);
        ArgumentNullException.ThrowIfNull(slot);
        _applicationContext.Remove(slot);
        await _applicationContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<ShipmentSlot> UpdateAsync(ShipmentSlot entity, CancellationToken cancellationToken)
    {
        _applicationContext.Update(entity);
        await _applicationContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<List<ShipmentSlot>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _applicationContext.ShipmentSlots
            .Include(s => s.Order)
            .Include(s => s.Courier)
            .ToListAsync(cancellationToken: cancellationToken);
    }
}