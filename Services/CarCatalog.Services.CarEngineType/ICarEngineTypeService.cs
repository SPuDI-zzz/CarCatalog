namespace CarCatalog.Services.CarEngineType;

public interface ICarEngineTypeService
{
    Task<IEnumerable<CarEngineTypeModel>> GetCarEngineTypes();
    Task<CarEngineTypeModel> GetCarEngineType(int carEngineTypeId);
}
