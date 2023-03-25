namespace CarCatalog.Services.CarBodyType;

public interface ICarBodyTypeService
{
    Task<IEnumerable<CarBodyTypeModel>> GetCarBodyTypes(int offset = 0, int limit = 10);
    Task<CarBodyTypeModel> GetCarBodyType(int carBodyTypeId);
}
