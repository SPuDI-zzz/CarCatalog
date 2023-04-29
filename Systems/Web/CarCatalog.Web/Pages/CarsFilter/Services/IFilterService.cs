namespace CarCatalog.Web.Pages.CarsFilter;

public interface IFilterService
{
    Task<IEnumerable<CarListItem>> GetCarsFilter(GetCarsFilterModel model);
    Task<IEnumerable<CarMarkItem>> GetCarMarksList();
    Task<IEnumerable<CarModelItem>> GetCarModelsByCarMarkIdList(int? carMarkId);
    Task<IEnumerable<CarGenerationItem>> GetCarGenerationsByCarModelidList(int? carModelId);
    Task<IEnumerable<CarBodyTypeItem>> GetCarBodyTypesList();
    Task<IEnumerable<CarDriveTypeItem>> GetCarDriveTypesList();
    Task<IEnumerable<CarEngineTypeItem>> GetCarEgineTypesList();
    Task<IEnumerable<CarTransmissonItem>> GetCarTransmissonsList();
}
