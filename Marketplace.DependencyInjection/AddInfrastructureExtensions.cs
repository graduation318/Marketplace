using Marketplace.Infrastructure;
using Marketplace.Infrastructure.Providers;
using Marketplace.Service.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Marketplace.DependencyInjection;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service)
    {
        service.AddDbContext<ApplicationContext>();
        service.AddScoped<IHallProvider, HallProvider>();
        service.AddScoped<IHallSeatsProvider, HallSeatsProvider>();
        service.AddScoped<IMovieProvider, MovieProvider>();
        service.AddScoped<IPriceProvider, PriceProvider>();
        service.AddScoped<ISessionProvider, SessionProvider>();
        service.AddScoped<ITicketProvider, TicketProvider>();

        return service;
    }
}