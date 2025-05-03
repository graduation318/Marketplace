using Marketplace.Data;
using Marketplace.Infrastructure.Migrations;
using Marketplace.Service.Interface;
using Marketplace.Service.ModelsRequest;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infrastructure.Providers;

public class PaymentProvider : IPaymentProvider
{
    private readonly ApplicationContext _applicationContext;

    public PaymentProvider(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public async Task<Guid> AddAsync(Payment entity, CancellationToken cancellationToken)
    {
        _applicationContext.Payments.Add(entity);
        await _applicationContext.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<Payment?> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _applicationContext.Payments
            .Include(p => p.Order)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var payment = await FindAsync(id, cancellationToken);
        if (payment == null) return false;

        _applicationContext.Payments.Remove(payment);
        await _applicationContext.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<Payment> UpdateAsync(Payment entity, CancellationToken cancellationToken)
    {
        _applicationContext.Payments.Update(entity);
        await _applicationContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<IEnumerable<Payment>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _applicationContext.Payments
            .Include(p => p.Order)
            .ToListAsync(cancellationToken);
    }

    public async Task<Payment?> FindByOrderIdAsync(Guid orderId, CancellationToken cancellationToken)
    {
        return await _applicationContext.Payments
            .Include(p => p.Order)
            .FirstOrDefaultAsync(p => p.OrderId == orderId, cancellationToken);
    }

    public async Task<string> CreatePaymentAsync(PaymentRequest request, CancellationToken cancellationToken)
    {
        var payment = new Payment
        {
            Id = Guid.NewGuid(),
            OrderId = request.OrderId,
            Amount = request.Amount,
            PaymentMethod = request.PaymentMethod,
            Status = request.Status
        };

        _applicationContext.Payments.Add(payment);
        await _applicationContext.SaveChangesAsync(cancellationToken);
        return $"Payment {payment.Id} created successfully";
    }
}
