namespace CarCatalog.Services.CarEngineType;

using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddCarEngineTypeService(this IServiceCollection services)
    {
        services.AddSingleton<ICarEngineTypeService, CarEngineTypeService>();

        return services;
    }
}
