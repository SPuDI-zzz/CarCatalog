namespace CarCatalog.Services.CarEngineType;

public interface ICarEngineTypeService
{
    Task<IEnumerable<CarEngineTypeModel>> GetCarEngineTypes(int offset = 0, int limit = 10);
    Task<CarEngineTypeModel> GetCarEngineType(int carEngineTypeId);
}
