namespace CarCatalog.Services.CarTransmission;

public interface ICarTransmissionService
{
    Task<IEnumerable<CarTransmissionModel>> GetCarTransmissions();
    Task<CarTransmissionModel> GetCarTransmission(int carTransmissionId);
}
