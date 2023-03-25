namespace CarCatalog.Services.CarForSale;

using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddCarForSaleService(this IServiceCollection services)
    {
        services.AddSingleton<ICarForSaleService, CarForSaleService>();

        return services;
    }
}
