using Marketplace.Data;

namespace Marketplace.Service.Interface
{
    public interface ICharacteristicProvider : IBaseProvider<Characteristic>
    {
        Task<IEnumerable<Characteristic>> GetAllAsync(CancellationToken cancellationToken);
        Task<Characteristic?> FindAsync(Guid id, CancellationToken cancellationToken);
        Task AddAsync(Characteristic entity, CancellationToken cancellationToken);
        Task UpdateAsync(Characteristic entity, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);
        
    }
}