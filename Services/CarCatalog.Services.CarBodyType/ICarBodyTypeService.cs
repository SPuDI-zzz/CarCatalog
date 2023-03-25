namespace CarCatalog.Services.CarBodyType;

using CarCatalog.Services.CarBodyType.Models;

public interface ICarBodyTypeService
{
    Task<IEnumerable<CarBodyTypeModel>> GetCarBodyTypes(int offset = 0, int limit = 10);
    Task<CarBodyTypeModel> GetCarBodyType(int carBodyTypeId);
}
