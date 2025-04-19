using AutoMapper;
using Marketplace.Data;
using Marketplace.Service.Interface;
using Marketplace.Service.ModelsRequest;

namespace Marketplace.Service;

public class CategoryService : BaseService<Category, CategoryRequest, ICategoryProvider>, ICategoryService
{
    private readonly ICategoryProvider _provider;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryProvider provider, IMapper mapper) : base(provider, mapper)
    {
        _provider = provider;
        _mapper = mapper;
    }
}