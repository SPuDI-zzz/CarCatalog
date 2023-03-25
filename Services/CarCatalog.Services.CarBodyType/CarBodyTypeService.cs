namespace CarCatalog.Services.CarBodyType;

using AutoMapper;
using CarCatalog.Context;
using Microsoft.EntityFrameworkCore;

public class CarBodyTypeService : ICarBodyTypeService
{
    private readonly IDbContextFactory<MainDbContext> contextFactory;
    private readonly IMapper mapper;

    public CarBodyTypeService(IDbContextFactory<MainDbContext> contextFactory, IMapper mapper)
    {
        this.contextFactory = contextFactory;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<CarBodyTypeModel>> GetCarBodyTypes(int offset = 0, int limit = 10)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var carBodyTypes = context
            .CarBodyTypes
            .AsQueryable()
            ;

        carBodyTypes = carBodyTypes
            .Skip(Math.Max(offset, 0))
            .Take(Math.Max(0, Math.Min(limit, 100)))
            ;

        var data = (await carBodyTypes.ToListAsync())
            .Select(mapper.Map<CarBodyTypeModel>)
            ;

        return data;
    }

    public async Task<CarBodyTypeModel> GetCarBodyType(int carBodyTypeId)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var carBodyType = await context.CarBodyTypes
            .FirstOrDefaultAsync(x => x.Id.Equals(carBodyTypeId))
            ;

        var data = mapper.Map<CarBodyTypeModel>(carBodyType);

        return data;
    }
}
