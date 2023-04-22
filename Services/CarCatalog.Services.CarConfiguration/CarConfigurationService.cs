namespace CarCatalog.Services.CarConfiguration;

using AutoMapper;
using CarCatalog.Common.Exceptions;
using CarCatalog.Common.Validator;
using CarCatalog.Context;
using CarCatalog.Context.Entities;
using Microsoft.EntityFrameworkCore;

public class CarConfigurationService : ICarConfigurationService
{
    private readonly IDbContextFactory<MainDbContext> contextFactory;
    private readonly IMapper mapper;
    private readonly IModelValidator<GetCarConfigurationsModel> getCarConfigurationsModelValidator;
    private readonly IModelValidator<AddCarConfigurationModel> addCarConfigurationModelValidator;
    private readonly IModelValidator<UpdateCarConfigurationModel> updateCarConfigurationModelValidator;

    public CarConfigurationService(
        IDbContextFactory<MainDbContext> contextFactory
        , IMapper mapper
        , IModelValidator<GetCarConfigurationsModel> getCarConfigurationsModelValidator
        , IModelValidator<AddCarConfigurationModel> addCarConfigurationModelValidator
        , IModelValidator<UpdateCarConfigurationModel> updateCarConfigurationModelValidator
        )
    {
        this.contextFactory = contextFactory;
        this.mapper = mapper;
        this.getCarConfigurationsModelValidator = getCarConfigurationsModelValidator;
        this.addCarConfigurationModelValidator = addCarConfigurationModelValidator;
        this.updateCarConfigurationModelValidator = updateCarConfigurationModelValidator;
    }

    public async Task<IEnumerable<CarConfigurationModel>> GetCarConfigurations(GetCarConfigurationsModel model)
    {
        getCarConfigurationsModelValidator.Check(model);

        using var context = await contextFactory.CreateDbContextAsync();

        var carConfigurations = context
            .CarConfigurations
            .Include(x => x.CarDriveType)
            .Include(x => x.CarBodyType)
            .Include(x => x.CarEgineType)
            .Include(x => x.CarTransmission)
            .Include(x => x.CarGeneration)
            .AsQueryable()
            ;

        carConfigurations = carConfigurations
            .Skip(model.Offset)
            .Take(model.Limit)
            ;

        var data = (await carConfigurations.ToListAsync())
            .Select(mapper.Map<CarConfigurationModel>)
            ;

        return data;
    }

    public async Task<CarConfigurationModel> GetCarConfiguration(int carConfigurationId)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var carConfiguration = await context
            .CarConfigurations
            .Include(x => x.CarDriveType)
            .Include(x => x.CarBodyType)
            .Include(x => x.CarEgineType)
            .Include(x => x.CarTransmission)
            .Include(x => x.CarGeneration)
            .FirstOrDefaultAsync(x => x.Id.Equals(carConfigurationId))
            ;

        var data = mapper.Map<CarConfigurationModel>(carConfiguration);

        return data;
    }

    public async Task<CarConfigurationModel> AddCarConfiguration(AddCarConfigurationModel model)
    {
        addCarConfigurationModelValidator.Check(model);

        using var context = await contextFactory.CreateDbContextAsync();

        var carConfiguration = mapper.Map<CarConfiguration>(model);
        await context.AddAsync(carConfiguration);
        context.SaveChanges();

        return mapper.Map<CarConfigurationModel>(carConfiguration);
    }

    public async Task UpdateCarConfiguration(int carConfigurationId, UpdateCarConfigurationModel model)
    {
        updateCarConfigurationModelValidator.Check(model);

        using var context = await contextFactory.CreateDbContextAsync();

        var carConfiguration = await context.CarConfigurations.FirstOrDefaultAsync(x => x.Id.Equals(carConfigurationId))
            ?? throw new ProcessException($"The car configuration (id : {carConfigurationId}) was not found");

        carConfiguration = mapper.Map(model, carConfiguration);

        context.CarConfigurations.Update(carConfiguration);
        context.SaveChanges();
    }

    public async Task DeleteCarConfiguration(int carConfigurationId)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var carConfiguration = await context.CarConfigurations.FirstOrDefaultAsync(x => x.Id.Equals(carConfigurationId))
            ?? throw new ProcessException($"The car configuration (id : {carConfigurationId}) was not found");

        context.Remove(carConfiguration);
        context.SaveChanges();
    }
}
