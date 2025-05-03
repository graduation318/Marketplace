using Marketplace.Data;
using Marketplace.Infrastructure.Migrations;
using Marketplace.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infrastructure.Providers;

public class CharacteristicProvider : ICharacteristicProvider
{
    private readonly ApplicationContext _applicationContext;

    public CharacteristicProvider(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public async Task<Guid> AddAsync(Characteristic entity, CancellationToken cancellationToken)
    {
        _applicationContext.Characteristics.Add(entity);
        await _applicationContext.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    Task ICharacteristicProvider.UpdateAsync(Characteristic entity, CancellationToken cancellationToken)
    {
        return UpdateAsync(entity, cancellationToken);
    }

    public async Task<Characteristic?> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _applicationContext.Characteristics
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }

    Task ICharacteristicProvider.AddAsync(Characteristic entity, CancellationToken cancellationToken)
    {
        return AddAsync(entity, cancellationToken);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await FindAsync(id, cancellationToken);
        if (entity == null) return false;

        _applicationContext.Characteristics.Remove(entity);
        await _applicationContext.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<IEnumerable<Characteristic>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _applicationContext.Characteristics
            .ToListAsync(cancellationToken);
    }

    public async Task<Characteristic> UpdateAsync(Characteristic entity, CancellationToken cancellationToken)
    {
        _applicationContext.Characteristics.Update(entity);
        await _applicationContext.SaveChangesAsync(cancellationToken);
        return entity;
    }
}