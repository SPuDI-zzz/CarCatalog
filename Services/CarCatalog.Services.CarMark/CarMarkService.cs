namespace CarCatalog.Services.CarMark;

using AutoMapper;
using CarCatalog.Context;
using Microsoft.EntityFrameworkCore;

public class CarMarkService : ICarMarkService
{
    private readonly IDbContextFactory<MainDbContext> contextFactory;
    private readonly IMapper mapper;

    public CarMarkService(IDbContextFactory<MainDbContext> contextFactory, IMapper mapper)
    {
        this.contextFactory = contextFactory;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<CarMarkModel>> GetCarMarks(int offset = 0, int limit = 10)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var carMarks = context
            .CarMarks
            .Include(x => x.Country)
            .AsQueryable()
            ;

        carMarks = carMarks
            .Skip(Math.Max(offset, 0))
            .Take(Math.Max(0, Math.Min(limit, 100)))
            ;

        var data = (await carMarks.ToListAsync())
            .Select(mapper.Map<CarMarkModel>)
            ;

        return data;
    }

    public async Task<CarMarkModel> GetCarMark(int carMarkId)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var carMark = await context
            .CarMarks
            .Include(x => x.Country)
            .FirstOrDefaultAsync(x => x.Id.Equals(carMarkId))
            ;

        var data = mapper.Map<CarMarkModel>(carMark);

        return data;
    }
}
