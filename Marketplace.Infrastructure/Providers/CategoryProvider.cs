using Marketplace.Data;
using Marketplace.Infrastructure.Migrations;
using Marketplace.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infrastructure.Providers;

public class CategoryProvider : ICategoryProvider
{
    private readonly ApplicationContext _applicationContext;

    public CategoryProvider(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public async Task<Guid> AddAsync(Category entity, CancellationToken cancellationToken)
    {
        _applicationContext.Categories.Add(entity);
        await _applicationContext.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<Category?> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _applicationContext.Categories
            .Include(c => c.Products)
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var category = await FindAsync(id, cancellationToken);
        if (category == null)
            return false;

        _applicationContext.Categories.Remove(category);
        await _applicationContext.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<Category> UpdateAsync(Category entity, CancellationToken cancellationToken)
    {
        _applicationContext.Categories.Update(entity);
        await _applicationContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _applicationContext.Categories
            .Include(c => c.Products)
            .ToListAsync(cancellationToken);
    }

    public async Task<Category?> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        return await _applicationContext.Categories
            .Include(c => c.Products)
            .FirstOrDefaultAsync(c => c.Name == name, cancellationToken);
    }
}
