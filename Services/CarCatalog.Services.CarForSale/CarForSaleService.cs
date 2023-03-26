namespace CarCatalog.Services.CarForSale;

using AutoMapper;
using CarCatalog.Context;
using Microsoft.EntityFrameworkCore;

public class CarForSaleService : ICarForSaleService
{
    private readonly IDbContextFactory<MainDbContext> contextFactory;
    private readonly IMapper mapper;

    public CarForSaleService(IDbContextFactory<MainDbContext> contextFactory, IMapper mapper)
    {
        this.contextFactory = contextFactory;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<CarForSaleModel>> GetCarsForSale(int offset = 0, int limit = 10)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var carsForSale = context
            .CarsForSale
            .Include(x => x.CarConfiguration)
            .AsQueryable()
            ;

        carsForSale = carsForSale
            .Skip(Math.Max(offset, 0))
            .Take(Math.Max(0, Math.Min(limit, 100)))
            ;

        var data = (await carsForSale.ToListAsync())
            .Select(mapper.Map<CarForSaleModel>)
            ;

        return data;
    }

    public async Task<CarForSaleModel> GetCarForSale(int carForSaleId)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var carForSale = await context
            .CarsForSale
            .Include(x => x.CarConfiguration)
            .FirstOrDefaultAsync(x => x.Id.Equals(carForSaleId))
            ;

        var data = mapper.Map<CarForSaleModel>(carForSale);

        return data;
    }
}
