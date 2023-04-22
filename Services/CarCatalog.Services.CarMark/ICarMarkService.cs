namespace CarCatalog.Services.CarMark;

public interface ICarMarkService
{
    Task<IEnumerable<CarMarkModel>> GetCarMarks(GetCarMarksModel model);
    Task<CarMarkModel> GetCarMark(int carMarkId);
    Task<CarMarkModel> AddCarMark(AddCarMarkModel model);
    Task UpdateCarMark(int carMarkId, UpdateCarMarkModel model);
    Task DeleteCarMark(int carMarkId);
}
