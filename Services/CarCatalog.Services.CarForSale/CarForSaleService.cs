namespace CarCatalog.Services.CarForSale;

using AutoMapper;
using CarCatalog.Common.Exceptions;
using CarCatalog.Common.Validator;
using CarCatalog.Context;
using CarCatalog.Context.Entities;
using Microsoft.EntityFrameworkCore;

public class CarForSaleService : ICarForSaleService
{
    private readonly IDbContextFactory<MainDbContext> contextFactory;
    private readonly IMapper mapper;
    private readonly IModelValidator<GetCarsForSaleModel> getCarsForSaleModelValidator;
    private readonly IModelValidator<AddCarForSaleModel> addCarForSaleModelValidator;
    private readonly IModelValidator<UpdateCarForSaleModel> updateCarForSaleModelValidator;

    public CarForSaleService(
        IDbContextFactory<MainDbContext> contextFactory
        , IMapper mapper
        , IModelValidator<GetCarsForSaleModel> getCarsForSaleModelValidator
        , IModelValidator<AddCarForSaleModel> addCarForSaleModelValidator
        , IModelValidator<UpdateCarForSaleModel> updateCarForSaleModelValidator
        )
    {
        this.contextFactory = contextFactory;
        this.mapper = mapper;
        this.getCarsForSaleModelValidator = getCarsForSaleModelValidator;
        this.addCarForSaleModelValidator = addCarForSaleModelValidator;
        this.updateCarForSaleModelValidator = updateCarForSaleModelValidator;
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

    public async Task<CarForSaleModel> AddCarForSale(AddCarForSaleModel model)
    {
        addCarForSaleModelValidator.Check(model);

        using var context = await contextFactory.CreateDbContextAsync();

        var carForSale = mapper.Map<CarForSale>(model);
        await context.AddAsync(carForSale);
        context.SaveChanges();

        return mapper.Map<CarForSaleModel>(carForSale);
    }

    public async Task UpdateCarForSale(int carForSaleId, UpdateCarForSaleModel model)
    {
        updateCarForSaleModelValidator.Check(model);

        using var context = await contextFactory.CreateDbContextAsync();

        var carForSale = await context.CarsForSale.FirstOrDefaultAsync(x => x.Id.Equals(carForSaleId))
            ?? throw new ProcessException($"The car for sale (id : {carForSaleId}) was not found");

        carForSale = mapper.Map(model, carForSale);

        context.CarsForSale.Update(carForSale);
        context.SaveChanges();
    }

    public async Task DeleteCarForSale(int carForSaleId)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var carForSale = await context.CarsForSale.FirstOrDefaultAsync(x => x.Id.Equals(carForSaleId))
            ?? throw new ProcessException($"The car for sale (id : {carForSaleId}) was not found");

        context.Remove(carForSale);
        context.SaveChanges();
    }
}
