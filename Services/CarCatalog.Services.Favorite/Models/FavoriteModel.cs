namespace CarCatalog.Services.Favorite;

using AutoMapper;
using CarCatalog.Context.Entities;

public class FavoriteModel
{
    public int IdCarForSale { get; set; }

    public int IdUser { get; set; }
}

public class FavoriteModelProfile : Profile
{
    public FavoriteModelProfile()
    {
        CreateMap<Favorite, FavoriteModel>();
    }
}
