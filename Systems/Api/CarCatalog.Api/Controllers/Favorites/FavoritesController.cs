namespace CarCatalog.Api.Controllers.Favorites;

using AutoMapper;
using CarCatalog.Api.Controllers.CarsForSale.Models;
using CarCatalog.Api.Controllers.Favorites.Models;
using CarCatalog.Common.Security;
using CarCatalog.Services.CarForSale;
using CarCatalog.Services.Favorite;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Produces("application/json")]
[Route("api/v{version:apiVersion}/favorites")]
[ApiController]
[ApiVersion("1.0")]
public class FavoritesController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly IFavoriteService favoriteService;

    public FavoritesController(IMapper mapper, IFavoriteService favoriteService)
    {
        this.mapper = mapper;
        this.favoriteService = favoriteService;
    }

    
    [ProducesResponseType(typeof(IEnumerable<FavoriteResponse>), 200)]
    [HttpGet("{userId}")]
    [Authorize(Policy = AppScopes.FavoritesWrite)]
    public async Task<IEnumerable<FavoriteResponse>> GetFavoritesByUserId([FromRoute] int userId)
    {
        var favorites = await favoriteService.GetFavoritesByUserId(userId);
        var response = mapper.Map<IEnumerable<FavoriteResponse>>(favorites);

        return response;
    }

    [HttpPost("")]
    [Authorize(Policy = AppScopes.FavoritesWrite)]
    public async Task<FavoriteResponse> AddFavorite([FromBody] AddFavoriteRequest request)
    {
        var model = mapper.Map<AddFavoriteModel>(request);
        var favorite = await favoriteService.AddFavorite(model);
        var response = mapper.Map<FavoriteResponse>(favorite);

        return response;
    }

    [HttpDelete("")]
    [Authorize(Policy = AppScopes.FavoritesWrite)]
    public async Task<IActionResult> DeleteFavorite([FromBody] DeleteFavoriteRequest model)
    {
        await favoriteService.DeleteFavorite(mapper.Map<DeleteFavoriteModel>(model));

        return Ok();
    }
}
