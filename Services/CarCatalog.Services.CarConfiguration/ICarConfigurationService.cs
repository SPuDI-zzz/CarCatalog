namespace CarCatalog.Services.CarConfiguration;

public interface ICarConfigurationService
{
    Task<IEnumerable<CarConfigurationModel>> GetCarConfigurations(GetCarConfigurationsModel model);
    Task<CarConfigurationModel> GetCarConfiguration(int carConfigurationId);
}
