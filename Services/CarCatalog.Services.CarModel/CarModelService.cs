namespace CarCatalog.Services.CarModel;

using AutoMapper;
using CarCatalog.Common.Exceptions;
using CarCatalog.Common.Validator;
using CarCatalog.Context;
using CarCatalog.Context.Entities;
using Microsoft.EntityFrameworkCore;

public class CarModelService : ICarModelService
{
    private readonly IDbContextFactory<MainDbContext> contextFactory;
    private readonly IMapper mapper;
    private readonly IModelValidator<GetCarModelsModel> getCarModelsModelValidator;
    private readonly IModelValidator<AddCarModelModel> addCarModelsModelValidator;
    private readonly IModelValidator<UpdateCarModelModel> updateCarModelsModelValidator;

    public CarModelService(
        IDbContextFactory<MainDbContext> contextFactory
        , IMapper mapper
        , IModelValidator<GetCarModelsModel> getCarModelsModelValidator
        , IModelValidator<AddCarModelModel> addCarModelsModelValidator
        , IModelValidator<UpdateCarModelModel> updateCarModelsModelValidator
        )
    {
        this.contextFactory = contextFactory;
        this.mapper = mapper;
        this.getCarModelsModelValidator = getCarModelsModelValidator;
        this.addCarModelsModelValidator = addCarModelsModelValidator;
        this.updateCarModelsModelValidator = updateCarModelsModelValidator;
    }

    public async Task<IEnumerable<CarModelModel>> GetCarModels(GetCarModelsModel model)
    {
        getCarModelsModelValidator.Check(model);

        using var context = await contextFactory.CreateDbContextAsync();

        var carModels = context
            .CarModels
            .Include(x => x.CarMark)
            .AsQueryable()
            ;

        carModels = carModels
            .Skip(model.Offset)
            .Take(model.Limit)
            ;

        var data = (await carModels.ToListAsync())
            .Select(mapper.Map<CarModelModel>)
            ;

        return data;
    }

    public async Task<CarModelModel> GetCarModel(int carModelId)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var carModel = await context
            .CarModels
            .Include(x => x.CarMark)
            .FirstOrDefaultAsync(x => x.Id.Equals(carModelId))
            ;

        var data = mapper.Map<CarModelModel>(carModel);

        return data;
    }

    public async Task<CarModelModel> AddCarModel(AddCarModelModel model)
    {
        addCarModelsModelValidator.Check(model);

        using var context = await contextFactory.CreateDbContextAsync();

        var carModel = mapper.Map<CarModel>(model);
        await context.AddAsync(carModel);
        context.SaveChanges();

        return mapper.Map<CarModelModel>(carModel);
    }

    public async Task UpdateCarModel(int carModelId, UpdateCarModelModel model)
    {
        updateCarModelsModelValidator.Check(model);

        using var context = await contextFactory.CreateDbContextAsync();

        var carModel = await context.CarModels.FirstOrDefaultAsync(x => x.Id.Equals(carModelId))
            ?? throw new ProcessException($"The car model (id : {carModelId}) was not found");

        carModel = mapper.Map(model, carModel);

        context.CarModels.Update(carModel);
        context.SaveChanges();  
    }

    public async Task DeleteCarModel(int carModelId)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var carModel = await context.CarModels.FirstOrDefaultAsync(x => x.Id.Equals(carModelId))
            ?? throw new ProcessException($"The car model (id : {carModelId}) was not found");

        context.Remove(carModel);
        context.SaveChanges();
    }
}
