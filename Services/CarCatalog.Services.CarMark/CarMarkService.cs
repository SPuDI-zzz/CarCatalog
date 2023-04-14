namespace CarCatalog.Services.CarMark;

using AutoMapper;
using CarCatalog.Common.Validator;
using CarCatalog.Context;
using Microsoft.EntityFrameworkCore;

public class CarMarkService : ICarMarkService
{
    private readonly IDbContextFactory<MainDbContext> contextFactory;
    private readonly IMapper mapper;
    private readonly IModelValidator<GetCarMarksModel> getCarMarksModelValidator;

    public CarMarkService(
        IDbContextFactory<MainDbContext> contextFactory
        , IMapper mapper
        , IModelValidator<GetCarMarksModel> getCarMarksModelValidator
        )
    {
        this.contextFactory = contextFactory;
        this.mapper = mapper;
        this.getCarMarksModelValidator = getCarMarksModelValidator;
    }

    public async Task<IEnumerable<CarMarkModel>> GetCarMarks(GetCarMarksModel model)
    {
        getCarMarksModelValidator.Check(model);

        using var context = await contextFactory.CreateDbContextAsync();

        var carMarks = context
            .CarMarks
            .Include(x => x.Country)
            .AsQueryable()
            ;

        carMarks = carMarks
            .Skip(model.Offset)
            .Take(model.Limit)
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
