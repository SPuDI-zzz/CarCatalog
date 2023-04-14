namespace CarCatalog.Services.CarForSale;

using AutoMapper;
using CarCatalog.Common.Validator;
using CarCatalog.Context;
using Microsoft.EntityFrameworkCore;

public class CarForSaleService : ICarForSaleService
{
    private readonly IDbContextFactory<MainDbContext> contextFactory;
    private readonly IMapper mapper;
    private readonly IModelValidator<GetCarsForSaleModel> getCarsForSaleModelValidator;

    public CarForSaleService(
        IDbContextFactory<MainDbContext> contextFactory
        , IMapper mapper
        , IModelValidator<GetCarsForSaleModel> getCarsForSaleModelValidator
        )
    {
        this.contextFactory = contextFactory;
        this.mapper = mapper;
        this.getCarsForSaleModelValidator = getCarsForSaleModelValidator;
    }

    public async Task<IEnumerable<CarForSaleModel>> GetCarsForSale(GetCarsForSaleModel model)
    {
        getCarsForSaleModelValidator.Check(model);

        using var context = await contextFactory.CreateDbContextAsync();

        var carsForSale = context
            .CarsForSale
            .Include(x => x.CarConfiguration)
            .AsQueryable()
            ;

        carsForSale = carsForSale
            .Skip(model.Offset)
            .Take(model.Limit)
            ;

        var data = (await carsForSale.ToListAsync())
            .Select(mapper.Map<CarForSaleModel>)
            ;

        return data;
    }

    public async Task<CarForSaleModel> GetCarForSale(int carForSaleId)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var carForSale = await context
            .CarsForSale
            .Include(x => x.CarConfiguration)
            .FirstOrDefaultAsync(x => x.Id.Equals(carForSaleId))
            ;

        var data = mapper.Map<CarForSaleModel>(carForSale);

        return data;
    }
}
