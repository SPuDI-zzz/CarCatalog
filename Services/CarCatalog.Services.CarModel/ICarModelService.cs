namespace CarCatalog.Services.CarModel;

public interface ICarModelService
{
    Task<IEnumerable<CarModelModel>> GetCarModels(GetCarModelsModel model);
    Task<CarModelModel> GetCarModel(int carModelId);
}
