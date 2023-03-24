namespace CarCatalog.Api.Controllers.Countries.Models;

using AutoMapper;
using CarCatalog.Services.Country;

public class CountryResponse
{
    /// <summary>
    /// Country Id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Country name
    /// </summary>
    public string Name { get; set; } = string.Empty;
}

public class CountryResponseProfile : Profile
{
    public CountryResponseProfile()
    {
        CreateMap<CountryModel, CountryResponse>();
    }
}
