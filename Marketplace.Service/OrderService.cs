using AutoMapper;
using Marketplace.Data;
using Marketplace.Service.Interface;
using Marketplace.Service.ModelsRequest;

namespace Marketplace.Service
{
    public class OrderService : BaseService<Order, OrderRequest, IOrderProvider>, IOrderService
    {
        private readonly IOrderProvider _provider;
        private readonly IMapper _mapper;

        public OrderService(IOrderProvider provider, IMapper mapper) : base(provider, mapper)
        {
            _provider = provider;
            _mapper = mapper;
        }

        public async Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _provider.FindByIdWithDetailsAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<Order>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _provider.GetAllAsync(cancellationToken);
        }

        public async Task<IEnumerable<Order>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            return await _provider.GetByUserIdAsync(userId, cancellationToken);
        }

        public async Task<Order> CreateAsync(OrderRequest request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Order>(request);
            await _provider.AddAsync(order, cancellationToken);
            return order;
        }

        public async Task<Order> UpdateAsync(Guid id, OrderRequest request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Order>(request);
            order.Id = id;
            await _provider.UpdateAsync(order, cancellationToken);
            return order;
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _provider.DeleteAsync(id, cancellationToken);
        }
    }
}