namespace CarCatalog.Services.CarGeneration;

using AutoMapper;
using CarCatalog.Common.Exceptions;
using CarCatalog.Common.Validator;
using CarCatalog.Context;
using CarCatalog.Context.Entities;
using Microsoft.EntityFrameworkCore;

public class CarGenerationService : ICarGenerationService
{
    private readonly IDbContextFactory<MainDbContext> contextFactory;
    private readonly IMapper mapper;
    private readonly IModelValidator<GetCarGenerationsModel> getCarGenerationsModelValidator;
    private readonly IModelValidator<AddCarGenerationModel> addCarGenerationModelValidator;
    private readonly IModelValidator<UpdateCarGenerationModel> updateCarGenerationModelValidator;

    public CarGenerationService(
        IDbContextFactory<MainDbContext> contextFactory
        , IMapper mapper
        , IModelValidator<GetCarGenerationsModel> getCarGenerationsModelValidator
        , IModelValidator<AddCarGenerationModel> addCarGenerationModelValidator
        , IModelValidator<UpdateCarGenerationModel> updateCarGenerationModelValidator
        )
    {
        this.contextFactory = contextFactory;
        this.mapper = mapper;
        this.getCarGenerationsModelValidator = getCarGenerationsModelValidator;
        this.addCarGenerationModelValidator = addCarGenerationModelValidator;
        this.updateCarGenerationModelValidator = updateCarGenerationModelValidator;
    }

    public async Task<IEnumerable<CarGenerationModel>> GetCarGenerations(GetCarGenerationsModel model)
    {
        getCarGenerationsModelValidator.Check(model);

        using var context = await contextFactory.CreateDbContextAsync();

        var carGenerations = context
            .CarGenerations
            .Include(x => x.CarModel)
            .AsQueryable()
            ;

        carGenerations = carGenerations
            .Skip(model.Offset)
            .Take(model.Limit)
            ;

        var data = (await carGenerations.ToListAsync())
            .Select(mapper.Map<CarGenerationModel>)
            ;

        return data;
    }

    public async Task<CarGenerationModel> GetCarGeneration(int carGenerationId)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var carGeneration = await context
            .CarGenerations
            .Include(x => x.CarModel)
            .FirstOrDefaultAsync(x => x.Id.Equals(carGenerationId))
            ;

        var data = mapper.Map<CarGenerationModel>(carGeneration);

        return data;
    }

    public async Task<CarGenerationModel> AddCarGeneration(AddCarGenerationModel model)
    {
        addCarGenerationModelValidator.Check(model);

        using var context = await contextFactory.CreateDbContextAsync();

        var carGeneration = mapper.Map<CarGeneration>(model);
        await context.AddAsync(carGeneration);
        context.SaveChanges();

        return mapper.Map<CarGenerationModel>(carGeneration);
    }

    public async Task UpdateCarGeneration(int carGenerationId, UpdateCarGenerationModel model)
    {
        updateCarGenerationModelValidator.Check(model);

        using var context = await contextFactory.CreateDbContextAsync();

        var carGeneration = await context.CarGenerations.FirstOrDefaultAsync(x => x.Id.Equals(carGenerationId))
            ?? throw new ProcessException($"The car generation (id : {carGenerationId}) was not found");

        carGeneration = mapper.Map(model, carGeneration);

        context.CarGenerations.Update(carGeneration);
        context.SaveChanges();
    }

    public async Task DeleteCarGeneration(int carGenerationId)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var carGeneration = await context.CarGenerations.FirstOrDefaultAsync(x => x.Id.Equals(carGenerationId))
            ?? throw new ProcessException($"The car generation (id : {carGenerationId}) was not found");

        context.Remove(carGeneration);
        context.SaveChanges();
    }
}
