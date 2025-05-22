using Marketplace.Service;
using Marketplace.Service.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Marketplace.DependencyInjection;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service.AddScoped(typeof(BaseService<,,>));
        
        service.AddScoped<IProductService, ProductService>();
        service.AddScoped<IOrderService, OrderService>();
        service.AddScoped<IUserService, UserService>();
        service.AddScoped<ICategoryService, CategoryService>();
        service.AddScoped<ICharacteristicService, CharacteristicService>();
        service.AddScoped<IPaymentService, PaymentService>();
        service.AddScoped<IShipmentService, ShipmentService>();

        return service;
    }
}