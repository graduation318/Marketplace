using AutoMapper;
using Marketplace.Data;
using Marketplace.Service.Interface;
using Marketplace.Service.ModelsRequest;
using Marketplace.Service.CustomException;
using NotExistException = Marketplace.Service.Exception.NotExistException;

namespace Marketplace.Service;

public class BaseService<TEntityDb, TEntityRequest, TEntityProvider> : IBaseService<TEntityDb, TEntityRequest>
    where TEntityDb : BaseModel
    where TEntityRequest : BaseModelRequest
    where TEntityProvider : IBaseProvider<TEntityDb>
{
    private readonly IMapper _mapper;
    private readonly TEntityProvider _provider;

    public BaseService(TEntityProvider provider, IMapper mapper)
    {
        _provider = provider;
        _mapper = mapper;
    }

    public virtual async Task<Guid> CreateAsync(TEntityRequest entityRequest, CancellationToken cancellationToken)
    {
        var existing = await _provider.FindAsync(entityRequest.Id, cancellationToken);
        if (existing != null)
            throw new ExistIsEntityException("Запись с таким ID уже существует");

        var entity = _mapper.Map<TEntityDb>(entityRequest);
        await _provider.AddAsync(entity, cancellationToken);
        return entity.Id;
    }

    public async Task<TEntityDb?> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _provider.FindAsync(id, cancellationToken);
        if (entity == null)
            throw new NotExistException("Запись не найдена");
        return entity;
    }

    public async Task<TEntityDb> UpdateAsync(TEntityRequest entityRequest, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<TEntityDb>(entityRequest);
        await _provider.UpdateAsync(entity, cancellationToken);
        return entity;
    }

    public async Task<List<TEntityDb>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _provider.GetAllAsync(cancellationToken);
    }
}
