namespace CarCatalog.Services.CarGeneration;

using AutoMapper;
using CarCatalog.Context;
using Microsoft.EntityFrameworkCore;

public class CarGenerationService : ICarGenerationService
{
    private readonly IDbContextFactory<MainDbContext> contextFactory;
    private readonly IMapper mapper;

    public CarGenerationService(IDbContextFactory<MainDbContext> contextFactory, IMapper mapper)
    {
        this.contextFactory = contextFactory;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<CarGenerationModel>> GetCarGenerations(int offset = 0, int limit = 10)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var carGenerations = context
            .CarGenerations
            .Include(x => x.CarModel)
            .AsQueryable()
            ;

        carGenerations = carGenerations
            .Skip(Math.Max(offset, 0))
            .Take(Math.Max(0, Math.Min(limit, 100)))
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
