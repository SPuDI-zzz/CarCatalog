namespace CarCatalog.Services.CarModel;

using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddCarModelService(this IServiceCollection services)
    {
        services.AddSingleton<ICarModelService, CarModelService>();

        return services;
    }
}
