namespace CarCatalog.Services.CarFilter;

public interface ICarFilterService
{
    Task<IEnumerable<CarFilterModel>> Index(GetCarsFilterModel model);
}
