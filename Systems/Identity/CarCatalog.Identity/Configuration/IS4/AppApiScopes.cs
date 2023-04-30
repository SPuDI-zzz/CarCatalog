namespace CarCatalog.Identity.Configuration;

using CarCatalog.Common.Security;
using Duende.IdentityServer.Models;

public static class AppApiScopes
{
    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new ApiScope(AppScopes.CarsWrite, "Access to cars API - Write data"),
            new ApiScope(AppScopes.CommentsWrite, "Access to comments API - Write data"),
            new ApiScope(AppScopes.FavoritesWrite, "Access to favorites API - Write data")
        };
}
