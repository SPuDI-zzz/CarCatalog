namespace CarCatalog.Api.Controllers.Favorites.Models;

using AutoMapper;
using CarCatalog.Services.Favorite;

public class FavoriteResponse
{
    public int IdCarForSale { get; set; }

    public int IdUser { get; set; }
}

public class FavoriteResponseProfile : Profile
{
    public FavoriteResponseProfile()
    {
        CreateMap<FavoriteModel, FavoriteResponse>();
    }
}
