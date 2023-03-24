namespace CarCatalog.Services.Country;

using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddCountryService(this IServiceCollection services)
    {
        services.AddSingleton<ICountryService, CountryService>();

        return services;
    }
}