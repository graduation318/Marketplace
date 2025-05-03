using AutoMapper;
using Marketplace.Data;
using Marketplace.Service.Interface;
using Marketplace.Service.ModelsRequest;

namespace Marketplace.Service
{
    public class CategoryService : BaseService<Category, CategoryRequest, ICategoryProvider>, ICategoryService
    {
        private readonly ICategoryProvider _provider;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryProvider provider, IMapper mapper) : base(provider, mapper)
        {
            _provider = provider;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _provider.GetAllAsync(cancellationToken);
        }

        public async Task<Category?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _provider.FindAsync(id, cancellationToken);
        }

        public async Task<Category?> GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await _provider.GetByNameAsync(name, cancellationToken);
        }

        public async Task<Category> CreateAsync(CategoryRequest request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request);
            await _provider.AddAsync(category, cancellationToken);
            return category;
        }

        public async Task<Category> UpdateAsync(Guid id, CategoryRequest request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request);
            category.Id = id;
            await _provider.UpdateAsync(category, cancellationToken);
            return category;
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _provider.DeleteAsync(id, cancellationToken);
        }
    }
}