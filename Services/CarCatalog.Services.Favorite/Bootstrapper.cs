namespace CarCatalog.Services.Favorite;

using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddFavoriteService(this IServiceCollection services)
    {
        services.AddSingleton<IFavoriteService, FavoriteService>();

        return services;
    }
}
