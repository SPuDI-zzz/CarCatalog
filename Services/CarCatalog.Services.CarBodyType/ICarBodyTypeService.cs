namespace CarCatalog.Services.CarBodyType;

public interface ICarBodyTypeService
{
    Task<IEnumerable<CarBodyTypeModel>> GetCarBodyTypes();
    Task<CarBodyTypeModel> GetCarBodyType(int carBodyTypeId);
}
