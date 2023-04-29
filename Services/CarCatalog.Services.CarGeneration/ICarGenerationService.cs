namespace CarCatalog.Services.CarGeneration;

public interface ICarGenerationService
{
    Task<IEnumerable<CarGenerationModel>> GetCarGenerations(GetCarGenerationsModel model);
    Task<IEnumerable<CarGenerationModel>> GetCarGenerationsByCarModelId(int carModelId);
    Task<CarGenerationModel> GetCarGeneration(int carGenerationId);
    Task<CarGenerationModel> AddCarGeneration(AddCarGenerationModel model);
    Task UpdateCarGeneration(int carGenerationId, UpdateCarGenerationModel model);
    Task DeleteCarGeneration(int carGenerationId);
}
