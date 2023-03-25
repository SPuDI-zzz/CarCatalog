namespace CarCatalog.Services.CarBodyType;

using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddCarBodyTypeService(this IServiceCollection services)
    {
        services.AddSingleton<ICarBodyTypeService, CarBodyTypeService>();

        return services;
    }
}
