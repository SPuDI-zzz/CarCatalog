namespace CarCatalog.Services.CarEngineType;

using AutoMapper;
using CarCatalog.Context;
using Microsoft.EntityFrameworkCore;

public class CarEngineTypeService : ICarEngineTypeService
{
    private readonly IDbContextFactory<MainDbContext> contextFactory;
    private readonly IMapper mapper;

    public CarEngineTypeService(
        IDbContextFactory<MainDbContext> contextFactory
        , IMapper mapper
        )
    {
        this.contextFactory = contextFactory;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<CarEngineTypeModel>> GetCarEngineTypes()
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var carEngineTypes = context
            .CarEngineTypes
            .AsQueryable()
            ;

        var data = (await carEngineTypes.ToListAsync())
            .Select(mapper.Map<CarEngineTypeModel>)
            ;

        return data;
    }

    public async Task<CarEngineTypeModel> GetCarEngineType(int carEngineTypeId)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var carEngineType = await context
            .CarEngineTypes
            .FirstOrDefaultAsync(x => x.Id.Equals(carEngineTypeId))
            ;

        var data = mapper.Map<CarEngineTypeModel>(carEngineType);

        return data;
    }
}
