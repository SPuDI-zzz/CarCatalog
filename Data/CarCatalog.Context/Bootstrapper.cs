﻿namespace CarCatalog.Context;

using CarCatalog.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    /// <summary>
    /// Register db context
    /// </summary>
    public static IServiceCollection AddAppDbContext(this IServiceCollection services, IConfiguration configuration = null)
    {
        var settings = Settings.Load<DbSettings>("Database", configuration);
        services.AddSingleton(settings);

        var dbInitOptionsDelegate = DbContextOptionsFactory.Configure(
            settings.ConnectionString);

        services.AddDbContextFactory<MainDbContext>(dbInitOptionsDelegate);

        return services;
    }
}
