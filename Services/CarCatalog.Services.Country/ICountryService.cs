namespace CarCatalog.Services.Country;

public interface ICountryService
{
    Task<IEnumerable<CountryModel>> GetCountries();
    Task<CountryModel> GetCountry(int countryId);
}
