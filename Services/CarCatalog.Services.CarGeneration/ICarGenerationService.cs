namespace CarCatalog.Services.CarGeneration;

public interface ICarGenerationService
{
    Task<IEnumerable<CarGenerationModel>> GetCarGenerations(int offset = 0, int limit = 10);
    Task<CarGenerationModel> GetCarGeneration(int carGenerationId);
}
