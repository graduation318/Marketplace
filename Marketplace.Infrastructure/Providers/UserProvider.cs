using Marketplace.Data;
using Marketplace.Infrastructure.Migrations;
using Marketplace.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infrastructure.Providers;

public class UserProvider : IUserProvider
{
    private readonly ApplicationContext _applicationContext;

    public UserProvider(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public async Task<Guid> AddAsync(User entity, CancellationToken cancellationToken)
    {
        _applicationContext.Users.Add(entity);
        await _applicationContext.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<User?> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _applicationContext.Users
            .Include(u => u.Orders)
            .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await FindAsync(id, cancellationToken);
        if (user == null) return false;

        _applicationContext.Users.Remove(user);
        await _applicationContext.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<User> UpdateAsync(User entity, CancellationToken cancellationToken)
    {
        _applicationContext.Users.Update(entity);
        await _applicationContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _applicationContext.Users
            .Include(u => u.Orders)
            .ToListAsync(cancellationToken);
    }

    public async Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken = default)
    {
        return await _applicationContext.Users
            .Include(u => u.Orders)
            .FirstOrDefaultAsync(u => u.Username == username, cancellationToken);
    }
}