namespace CarCatalog.Services.CarConfiguration;

public interface ICarConfigurationService
{
    Task<IEnumerable<CarConfigurationModel>> GetCarConfigurations(GetCarConfigurationsModel model);
    Task<CarConfigurationModel> GetCarConfiguration(int carConfigurationId);
    Task<CarConfigurationModel> AddCarConfiguration(AddCarConfigurationModel model);
    Task UpdateCarConfiguration(int carConfigurationId, UpdateCarConfigurationModel model);
    Task DeleteCarConfiguration(int carConfigurationId);
}
