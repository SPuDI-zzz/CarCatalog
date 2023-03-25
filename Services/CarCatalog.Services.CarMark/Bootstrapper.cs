namespace CarCatalog.Services.CarMark;

using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddCarMarkService(this IServiceCollection services)
    {
        services.AddSingleton<ICarMarkService, CarMarkService>();

        return services;
    }
}
