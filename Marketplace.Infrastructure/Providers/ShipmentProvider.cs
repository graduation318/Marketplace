using Marketplace.Data;
using Marketplace.Data.Models;
using Marketplace.Infrastructure.Migrations;
using Marketplace.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infrastructure.Providers
{
    public class ShipmentProvider : IShipmentProvider
    {
        private readonly ApplicationContext _applicationContext;

        public ShipmentProvider(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<Guid> AddAsync(Shipment entity, CancellationToken cancellationToken)
        {
            _applicationContext.Add(entity);
            await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return entity.Id;
        }

        public async Task<Shipment?> FindAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _applicationContext.Shipments
                .Include(s => s.Order)
                .FirstOrDefaultAsync(s => s.Id == id, cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await FindAsync(id, cancellationToken);
            if (entity == null) return false;

            _applicationContext.Shipments.Remove(entity);
            await _applicationContext.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<Shipment> UpdateAsync(Shipment entity, CancellationToken cancellationToken)
        {
            _applicationContext.Update(entity);
            await _applicationContext.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<IEnumerable<Shipment>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _applicationContext.Shipments
                .Include(s => s.Order)
                .ToListAsync(cancellationToken);
        }

        public async Task<Shipment?> FindByOrderIdAsync(Guid orderId)
        {
            return await _applicationContext.Shipments
                .Include(s => s.Order)
                .FirstOrDefaultAsync(s => s.Order.Id == orderId);
        }

        public Task<string> CreateShipmentAsync(ShipmentRequest request)
        {
            // Заглушка: здесь может быть логика создания отправления через API.
            return Task.FromResult($"SHIPMENT-{Guid.NewGuid()}");
        }

        public Task<string> GetTrackingStatusAsync(string trackingNumber)
        {
            return Task.FromResult("In Transit");
        }
    }
}
