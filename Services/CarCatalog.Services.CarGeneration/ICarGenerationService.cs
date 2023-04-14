namespace CarCatalog.Services.CarGeneration;

public interface ICarGenerationService
{
    Task<IEnumerable<CarGenerationModel>> GetCarGenerations(GetCarGenerationsModel model);
    Task<CarGenerationModel> GetCarGeneration(int carGenerationId);
}
