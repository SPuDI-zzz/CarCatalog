namespace CarCatalog.Services.CarGeneration;

using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddCarGenerationService(this IServiceCollection services)
    {
        services.AddSingleton<ICarGenerationService, CarGenerationService>();

        return services;
    }
}
