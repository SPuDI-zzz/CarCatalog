namespace CarCatalog.Services.CarForSale;

public interface ICarForSaleService
{
    Task<IEnumerable<CarForSaleModel>> GetCarsForSale(GetCarsForSaleModel model);
    Task<CarForSaleModel> GetCarForSale(int carForSaleId);
    Task<CarForSaleModel> AddCarForSale(AddCarForSaleModel model);
    Task UpdateCarForSale(int carForSaleId, UpdateCarForSaleModel model);
    Task DeleteCarForSale(int carForSaleId);
}
