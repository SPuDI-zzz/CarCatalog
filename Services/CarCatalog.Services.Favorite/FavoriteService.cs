﻿using AutoMapper;
namespace CarCatalog.Services.Favorite;

using CarCatalog.Common.Exceptions;
using CarCatalog.Common.Validator;
using CarCatalog.Context;
using CarCatalog.Context.Entities;
using Microsoft.EntityFrameworkCore;

public class FavoriteService : IFavoriteService
{
    private readonly IDbContextFactory<MainDbContext> contextFactory;
    private readonly IMapper mapper;
    private readonly IModelValidator<AddFavoriteModel> addFavoriteModelValidator;

    public FavoriteService(
        IDbContextFactory<MainDbContext> contextFactory
        , IMapper mapper
        , IModelValidator<AddFavoriteModel> addFavoriteModelValidator
        )
    {
        this.contextFactory = contextFactory;
        this.mapper = mapper;
        this.addFavoriteModelValidator = addFavoriteModelValidator;
    }

    public async Task<IEnumerable<FavoriteModel>> GetFavoritesByUserId(int userId)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var favorites = context
            .Favorites
            .Where(x => x.IdUser.Equals(userId))
            ;

        var data = (await favorites.ToListAsync())
            .Select(mapper.Map<FavoriteModel>)
            ;

        return data;
    }

    public async Task<FavoriteModel> AddFavorite(AddFavoriteModel model)
    {
        addFavoriteModelValidator.Check(model);

        using var context = await contextFactory.CreateDbContextAsync();

        var favorite = mapper.Map<Favorite>(model);
        await context.AddAsync(favorite);
        context.SaveChanges();

        return mapper.Map<FavoriteModel>(favorite);
    }

    public async Task DeleteFavorite(int userId, int carForSaleId)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var favorite = await context.Favorites.FirstOrDefaultAsync(x => x.IdUser.Equals(userId) && x.IdCarForSale.Equals(carForSaleId))
            ?? throw new ProcessException("The favorite car was not found");

        context.Remove(favorite);
        context.SaveChanges();
    }
}
