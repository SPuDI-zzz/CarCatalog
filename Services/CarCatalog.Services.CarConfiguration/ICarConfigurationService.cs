namespace CarCatalog.Services.CarConfiguration;

public interface ICarConfigurationService
{
    Task<IEnumerable<CarConfigurationModel>> GetCarConfigurations(int offset = 0, int limit = 10);
    Task<CarConfigurationModel> GetCarConfiguration(int carConfigurationId);
}
