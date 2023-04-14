namespace CarCatalog.Services.CarDriveType;

public interface ICarDriveTypeService
{
    Task<IEnumerable<CarDriveTypeModel>> GetCarDriveTypes();
    Task<CarDriveTypeModel> GetCarDriveType(int carDriveTypeId);
}
