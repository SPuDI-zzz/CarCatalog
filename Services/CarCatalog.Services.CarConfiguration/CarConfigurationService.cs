namespace CarCatalog.Services.CarConfiguration;

using AutoMapper;
using CarCatalog.Context;
using Microsoft.EntityFrameworkCore;

public class CarConfigurationService : ICarConfigurationService
{
    private readonly IDbContextFactory<MainDbContext> contextFactory;
    private readonly IMapper mapper;

    public CarConfigurationService(IDbContextFactory<MainDbContext> contextFactory, IMapper mapper)
    {
        this.contextFactory = contextFactory;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<CarConfigurationModel>> GetCarConfigurations(int offset = 0, int limit = 10)
    {
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
            .Skip(Math.Max(offset, 0))
            .Take(Math.Max(0, Math.Min(limit, 100)))
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
