namespace CarCatalog.Services.CarFilter;

using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddCarFilterService(this IServiceCollection services)
    {
        services.AddSingleton<ICarFilterService, CarFilterService>();

        return services;
    }
}
