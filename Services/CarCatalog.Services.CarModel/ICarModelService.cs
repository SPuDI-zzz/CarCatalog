namespace CarCatalog.Services.CarModel;

public interface ICarModelService
{
    Task<IEnumerable<CarModelModel>> GetCarModels(GetCarModelsModel model);
    Task<IEnumerable<CarModelModel>> GetCarModelsByCarMarkId(int carMarkId);
    Task<CarModelModel> GetCarModel(int carModelId);
    Task<CarModelModel> AddCarModel(AddCarModelModel model);
    Task UpdateCarModel(int carModelId, UpdateCarModelModel model);
    Task DeleteCarModel(int carModelId);
}
