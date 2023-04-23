namespace CarCatalog.Services.Favorite;

public interface IFavoriteService
{
    Task<IEnumerable<FavoriteModel>> GetFavoritesByUserId(int userId);
    Task<FavoriteModel> AddFavorite(AddFavoriteModel model);
    Task DeleteFavorite(DeleteFavoriteModel model);
}
