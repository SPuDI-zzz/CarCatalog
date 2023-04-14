namespace CarCatalog.Services.CarGeneration;

using AutoMapper;
using CarCatalog.Common.Validator;
using CarCatalog.Context;
using Microsoft.EntityFrameworkCore;

public class CarGenerationService : ICarGenerationService
{
    private readonly IDbContextFactory<MainDbContext> contextFactory;
    private readonly IMapper mapper;
    private readonly IModelValidator<GetCarGenerationsModel> getCarGenerationsModelValidator;

    public CarGenerationService(
        IDbContextFactory<MainDbContext> contextFactory
        , IMapper mapper
        , IModelValidator<GetCarGenerationsModel> getCarGenerationsModelValidator
        )
    {
        this.contextFactory = contextFactory;
        this.mapper = mapper;
        this.getCarGenerationsModelValidator = getCarGenerationsModelValidator;
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
}
