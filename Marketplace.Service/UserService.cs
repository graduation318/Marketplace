using AutoMapper;
using Marketplace.Data;
using Marketplace.Service.Interface;
using Marketplace.Service.ModelsRequest;

namespace Marketplace.Service;

public class UserService : BaseService<User, UserRequest, IUserProvider>, IUserService
{
    private readonly IUserProvider _provider;
    private readonly IMapper _mapper;

    public UserService(IUserProvider provider, IMapper mapper) : base(provider, mapper)
    {
        _provider = provider;
        _mapper = mapper;
    }
}