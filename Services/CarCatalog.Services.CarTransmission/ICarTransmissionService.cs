namespace CarCatalog.Services.CarTransmission;

public interface ICarTransmissionService
{
    Task<IEnumerable<CarTransmissionModel>> GetCarTransmissions(int offset = 0, int limit = 10);
    Task<CarTransmissionModel> GetCarTransmission(int carTransmissionId);
}
