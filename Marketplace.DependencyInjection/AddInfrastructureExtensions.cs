using Marketplace.Infrastructure.Providers;
using Marketplace.Service.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Marketplace.DependencyInjection;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service)
    {
        service.AddScoped<ICategoryProvider, CategoryProvider>();
        service.AddScoped<ICharacteristicProvider, CharacteristicProvider>();
        service.AddScoped<IOrderProvider, OrderProvider>();
        service.AddScoped<IProductProvider, ProductProvider>();
        service.AddScoped<IShipmentProvider, ShipmentProvider>();
        service.AddScoped<IPaymentProvider, PaymentProvider>();

        return service;
    }
}