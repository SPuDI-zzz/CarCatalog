namespace CarCatalog.Api;

using CarCatalog.Api.Settings;
using CarCatalog.Services.CarBodyType;
using CarCatalog.Services.CarConfiguration;
using CarCatalog.Services.CarDriveType;
using CarCatalog.Services.CarEngineType;
using CarCatalog.Services.CarMark;
using CarCatalog.Services.Country;
using CarCatalog.Services.Settings;
using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection RegisterAppServices(this IServiceCollection services)
    {
        services
            .AddMainSettings()
            .AddSwaggerSettings()
            .AddApiSpecialSettings()
            .AddCountryService()
            .AddCarDriveTypeService()
            .AddCarMarkService()
            .AddCarBodyTypeService()
            .AddCarConfigurationService()
            .AddCarEngineTypeService()
            ;

        return services;
    }
}
