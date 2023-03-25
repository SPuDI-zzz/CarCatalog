namespace CarCatalog.Services.CarTransmission;

using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddCarTransmissionService(this IServiceCollection services)
    {
        services.AddSingleton<ICarTransmissionService, CarTransmissionService>();

        return services;
    }
}
