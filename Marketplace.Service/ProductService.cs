using AutoMapper;
using Marketplace.Data;
using Marketplace.Service.Interface;
using Marketplace.Service.ModelsRequest;

namespace Marketplace.Service;

public class ProductService : BaseService<Product, ProductRequest, IProductProvider>, IProductService
{
    private readonly IProductProvider _provider;
    private readonly IMapper _mapper;

    public ProductService(IProductProvider provider, IMapper mapper) : base(provider, mapper)
    {
        _provider = provider;
        _mapper = mapper;
    }
}