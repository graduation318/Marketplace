using AutoMapper;
using Marketplace.Data;
using Marketplace.Service.Interface;
using Marketplace.Service.ModelsRequest;

namespace Marketplace.Service;

public class CharacteristicService : BaseService<Characteristic, CharacteristicRequest, ICharacteristicProvider>, ICharacteristicService
{
    private readonly ICharacteristicProvider _provider;
    private readonly IMapper _mapper;

    public CharacteristicService(ICharacteristicProvider provider, IMapper mapper) : base(provider, mapper)
    {
        _provider = provider;
        _mapper = mapper;
    }
}