namespace CarCatalog.Services.CarDriveType;

public interface ICarDriveTypeService
{
    Task<IEnumerable<CarDriveTypeModel>> GetCarDriveTypes(int offset = 0, int limit = 10);
    Task<CarDriveTypeModel> GetCarDriveType(int countryId);
}
