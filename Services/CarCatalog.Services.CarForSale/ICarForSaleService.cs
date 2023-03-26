namespace CarCatalog.Services.CarForSale;

public interface ICarForSaleService
{
    Task<IEnumerable<CarForSaleModel>> GetCarsForSale(int offset = 0, int limit = 10);
    Task<CarForSaleModel> GetCarForSale(int carForSaleId);
}
