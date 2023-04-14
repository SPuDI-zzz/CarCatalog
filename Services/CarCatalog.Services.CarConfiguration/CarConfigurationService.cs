namespace CarCatalog.Services.CarConfiguration;

using AutoMapper;
using CarCatalog.Common.Validator;
using CarCatalog.Context;
using Microsoft.EntityFrameworkCore;

public class CarConfigurationService : ICarConfigurationService
{
    private readonly IDbContextFactory<MainDbContext> contextFactory;
    private readonly IMapper mapper;
    private readonly IModelValidator<GetCarConfigurationsModel> getCarConfigurationsModelValidator;

    public CarConfigurationService(
        IDbContextFactory<MainDbContext> contextFactory
        , IMapper mapper
        , IModelValidator<GetCarConfigurationsModel> getCarConfigurationsModelValidator
        )
    {
        this.contextFactory = contextFactory;
        this.mapper = mapper;
        this.getCarConfigurationsModelValidator = getCarConfigurationsModelValidator;
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
}
