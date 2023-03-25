namespace CarCatalog.Services.CarTransmission;

using AutoMapper;
using CarCatalog.Context;
using CarCatalog.Context.Entities;
using Microsoft.EntityFrameworkCore;

public class CarTransmissionService : ICarTransmissionService
{
    private readonly IDbContextFactory<MainDbContext> contextFactory;
    private readonly IMapper mapper;

    public CarTransmissionService(IDbContextFactory<MainDbContext> contextFactory, IMapper mapper)
    {
        this.contextFactory = contextFactory;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<CarTransmissionModel>> GetCarTransmissions(int offset = 0, int limit = 10)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var carTransmissions = context
            .CarTransmissions
            .AsQueryable()
            ;

        carTransmissions = carTransmissions
            .Skip(Math.Max(offset, 0))
            .Take(Math.Max(0, Math.Min(limit, 100)))
        ;

        var data = (await carTransmissions.ToListAsync())
            .Select(mapper.Map<CarTransmissionModel>)
            ;

        return data;
    }

    public async Task<CarTransmissionModel> GetCarTransmission(int carTransmissionId)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var carTransmission = await context.CarTransmissions
            .FirstOrDefaultAsync(x => x.Id.Equals(carTransmissionId))
            ;

        var data = mapper.Map<CarTransmissionModel>(carTransmission);

        return data;
    }
}
