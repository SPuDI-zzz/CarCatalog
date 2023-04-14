namespace CarCatalog.Services.CarModel;

using AutoMapper;
using CarCatalog.Common.Validator;
using CarCatalog.Context;
using Microsoft.EntityFrameworkCore;

public class CarModelService : ICarModelService
{
    private readonly IDbContextFactory<MainDbContext> contextFactory;
    private readonly IMapper mapper;
    private readonly IModelValidator<GetCarModelsModel> getCarModelsModelValidator;

    public CarModelService(
        IDbContextFactory<MainDbContext> contextFactory
        , IMapper mapper
        , IModelValidator<GetCarModelsModel> getCarModelsModelValidator
        )
    {
        this.contextFactory = contextFactory;
        this.mapper = mapper;
        this.getCarModelsModelValidator = getCarModelsModelValidator; 
    }

    public async Task<IEnumerable<CarModelModel>> GetCarModels(GetCarModelsModel model)
    {
        getCarModelsModelValidator.Check(model);

        using var context = await contextFactory.CreateDbContextAsync();

        var carModels = context
            .CarModels
            .Include(x => x.CarMark)
            .AsQueryable()
            ;

        carModels = carModels
            .Skip(model.Offset)
            .Take(model.Limit)
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
