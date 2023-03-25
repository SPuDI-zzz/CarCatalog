namespace CarCatalog.Services.CarConfiguration;

using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddCarConfigurationService(this IServiceCollection services)
    {
        services.AddSingleton<ICarConfigurationService, CarConfigurationService>();

        return services;
    }
}
