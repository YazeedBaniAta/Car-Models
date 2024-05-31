using Application.RepositoryInterfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {

        services.AddTransient(typeof(ICarMakeRepository), typeof(CarMakeRepository));

        return services;
    }

}
