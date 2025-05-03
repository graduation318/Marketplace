using Marketplace.Service;
using Marketplace.Service.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Marketplace.DependencyInjection;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {

        return service;
    }
}