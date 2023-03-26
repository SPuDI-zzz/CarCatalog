namespace CarCatalog.Services.CarModel;

public interface ICarModelService
{
    Task<IEnumerable<CarModelModel>> GetCarModels(int offset = 0, int limit = 10);
    Task<CarModelModel> GetCarModel(int carModelId);
}
