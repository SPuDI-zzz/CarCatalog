namespace CarCatalog.Services.CarMark;

public interface ICarMarkService
{
    Task<IEnumerable<CarMarkModel>> GetCarMarks(int offset = 0, int limit = 10);
    Task<CarMarkModel> GetCarMark(int carMarkId);
}
