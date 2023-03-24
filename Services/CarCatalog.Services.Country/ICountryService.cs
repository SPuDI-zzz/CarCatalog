namespace CarCatalog.Services.Country;

public interface ICountryService
{
    Task<IEnumerable<CountryModel>> GetCountries(int offset = 0, int limit = 10);
    Task<CountryModel> GetCountry(int countryId);
}