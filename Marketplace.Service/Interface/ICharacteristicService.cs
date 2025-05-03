using Marketplace.Data;
using Marketplace.Service.ModelsRequest;

namespace Marketplace.Service.Interface
{
    public interface ICharacteristicService
    {
        Task<Characteristic?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<Characteristic>> GetAllAsync(CancellationToken cancellationToken);
        Task<Characteristic> CreateAsync(CharacteristicRequest request, CancellationToken cancellationToken);
        Task<Characteristic> UpdateAsync(Guid id, CharacteristicRequest request, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}