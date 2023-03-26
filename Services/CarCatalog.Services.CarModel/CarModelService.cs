namespace CarCatalog.Services.CarModel;

using AutoMapper;
using CarCatalog.Context;
using Microsoft.EntityFrameworkCore;

public class CarModelService : ICarModelService
{
    private readonly IDbContextFactory<MainDbContext> contextFactory;
    private readonly IMapper mapper;

    public CarModelService(IDbContextFactory<MainDbContext> contextFactory, IMapper mapper)
    {
        this.contextFactory = contextFactory;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<CarModelModel>> GetCarModels(int offset = 0, int limit = 10)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var carModels = context
            .CarModels
            .Include(x => x.CarMark)
            .AsQueryable()
            ;

        carModels = carModels
            .Skip(Math.Max(offset, 0))
            .Take(Math.Max(0, Math.Min(limit, 100)))
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
}
