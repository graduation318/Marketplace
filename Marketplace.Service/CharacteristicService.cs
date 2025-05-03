using AutoMapper;
using Marketplace.Data;
using Marketplace.Service.Interface;
using Marketplace.Service.ModelsRequest;

namespace Marketplace.Service
{
    public class CharacteristicService : BaseService<Characteristic, CharacteristicRequest, ICharacteristicProvider>, ICharacteristicService
    {
        private readonly ICharacteristicProvider _provider;
        private readonly IMapper _mapper;

        public CharacteristicService(ICharacteristicProvider provider, IMapper mapper) : base(provider, mapper)
        {
            _provider = provider;
            _mapper = mapper;
        }

        public async Task<Characteristic?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _provider.FindAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<Characteristic>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _provider.GetAllAsync(cancellationToken);
        }

        public async Task<Characteristic> CreateAsync(CharacteristicRequest request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Characteristic>(request);
            await _provider.AddAsync(entity, cancellationToken);
            return entity;
        }

        public async Task<Characteristic> UpdateAsync(Guid id, CharacteristicRequest request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Characteristic>(request);
            entity.Id = id;
            await _provider.UpdateAsync(entity, cancellationToken);
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _provider.DeleteAsync(id, cancellationToken);
        }
    }
}