namespace CarCatalog.Services.CarDriveType;

using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddCarDriveTypeService(this IServiceCollection services)
    {
        services.AddSingleton<ICarDriveTypeService, CarDriveTypeService>();

        return services;
    }
}
