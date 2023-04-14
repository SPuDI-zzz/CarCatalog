namespace CarCatalog.Services.CarForSale;

public interface ICarForSaleService
{
    Task<IEnumerable<CarForSaleModel>> GetCarsForSale(GetCarsForSaleModel model);
    Task<CarForSaleModel> GetCarForSale(int carForSaleId);
}
