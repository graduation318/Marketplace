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

    public async Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken)
    {
        return await _provider.GetByUsernameAsync(username, cancellationToken);
    }

    public async Task<User> CreateAsync(UserRequest request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request);
        await _provider.AddAsync(user, cancellationToken);
        return user;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _provider.DeleteAsync(id, cancellationToken);
    }

    public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _provider.GetAllAsync(cancellationToken);
    }

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _provider.FindAsync(id, cancellationToken);
    }

    public async Task<User> UpdateAsync(Guid id, UserRequest request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request);
        user.Id = id;
        await _provider.UpdateAsync(user, cancellationToken);
        return user;
    }
}