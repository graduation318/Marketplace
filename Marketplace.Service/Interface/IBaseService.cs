using Marketplace.Data;
using Marketplace.Service.ModelsRequest;

namespace Marketplace.Service.Interface;

public interface IBaseService<TEntityDb, TEntityRequest>
{
    Task<Guid> CreateAsync(TEntityRequest entityRequest, CancellationToken cancellationToken);
    Task<TEntityDb?> GetAsync(Guid id, CancellationToken cancellationToken);
    Task<TEntityDb> UpdateAsync(TEntityRequest entityRequest, CancellationToken cancellationToken);
    Task<List<TEntityDb>> GetAllAsync(CancellationToken cancellationToken);
}