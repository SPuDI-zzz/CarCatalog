﻿namespace CarCatalog.Api;

using CarCatalog.Api.Settings;
using CarCatalog.Services.Actions;
using CarCatalog.Services.Cache;
using CarCatalog.Services.CarBodyType;
using CarCatalog.Services.CarConfiguration;
using CarCatalog.Services.CarDriveType;
using CarCatalog.Services.CarEngineType;
using CarCatalog.Services.CarFilter;
using CarCatalog.Services.CarForSale;
using CarCatalog.Services.CarGeneration;
using CarCatalog.Services.CarMark;
using CarCatalog.Services.CarModel;
using CarCatalog.Services.CarTransmission;
using CarCatalog.Services.Comment;
using CarCatalog.Services.Country;
using CarCatalog.Services.Favorite;
using CarCatalog.Services.RabbitMq;
using CarCatalog.Services.Settings;
using CarCatalog.Services.UserAccount;
using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection RegisterAppServices(this IServiceCollection services)
    {
        services
            .AddMainSettings()
            .AddSwaggerSettings()
            .AddIdentitySettings()
            .AddApiSpecialSettings()
            .AddCountryService()
            .AddCarDriveTypeService()
            .AddCarMarkService()
            .AddCarBodyTypeService()
            .AddCarConfigurationService()
            .AddCarEngineTypeService()
            .AddCarForSaleService()
            .AddCarGenerationService()
            .AddCarModelService()
            .AddCarTransmissionService()
            .AddUserAccountService()
            .AddCarFilterService()
            .AddFavoriteService()
            .AddCommentService()
            .AddCache()
            .AddRabbitMq()
            .AddActions()
            ;

        return services;
    }
}
