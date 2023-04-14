namespace CarCatalog.Services.CarMark;

public interface ICarMarkService
{
    Task<IEnumerable<CarMarkModel>> GetCarMarks(GetCarMarksModel model);
    Task<CarMarkModel> GetCarMark(int carMarkId);
}
