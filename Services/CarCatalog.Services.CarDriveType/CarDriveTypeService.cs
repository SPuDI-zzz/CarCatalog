namespace CarCatalog.Services.CarDriveType;

using AutoMapper;
using CarCatalog.Context;
using Microsoft.EntityFrameworkCore;

public class CarDriveTypeService : ICarDriveTypeService
{
    private readonly IDbContextFactory<MainDbContext> contextFactory;
    private readonly IMapper mapper;

    public CarDriveTypeService(IDbContextFactory<MainDbContext> contextFactory, IMapper mapper)
    {
        this.contextFactory = contextFactory;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<CarDriveTypeModel>> GetCarDriveTypes(int offset = 0, int limit = 10)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var carDriveTypes = context
            .CarDriveTypes
            .AsQueryable()
            ;

        carDriveTypes = carDriveTypes
            .Skip(Math.Max(offset, 0))
            .Take(Math.Max(0, Math.Min(limit, 100)))
            ;

        var data = (await carDriveTypes.ToListAsync())
            .Select(mapper.Map<CarDriveTypeModel>)
            ;

        return data;
    }

    public async Task<CarDriveTypeModel> GetCarDriveType(int carDriveTypeId)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var carDriveType = await context.CarDriveTypes
            .FirstOrDefaultAsync(x => x.Id.Equals(carDriveTypeId));

        var data = mapper.Map<CarDriveTypeModel>(carDriveType);

        return data;
    }
}
