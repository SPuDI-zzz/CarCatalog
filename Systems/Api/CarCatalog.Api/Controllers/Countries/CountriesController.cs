namespace CarCatalog.Api.Controllers.Countries;

using AutoMapper;
using CarCatalog.Api.Controllers.Countries.Models;
using CarCatalog.Services.Country;
using Microsoft.AspNetCore.Mvc;

[Produces("application/json")]
[Route("api/v{version:apiVersion}/countries")]
[ApiController]
[ApiVersion("1.0")]
public class CountriesController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly ICountryService countryService;

    public CountriesController(IMapper mapper, ICountryService countryService)
    {
        this.mapper = mapper;
        this.countryService = countryService;
    }

    [ProducesResponseType(typeof(IEnumerable<CountryResponse>), 200)]
    [HttpGet("")]
    public async Task<IEnumerable<CountryResponse>> GetCountries()
    {
        var countries = await countryService.GetCountries();
        var response = mapper.Map<IEnumerable<CountryResponse>>(countries);

        return response;
    }

    /// <summary>
    /// Get country by Id
    /// </summary>
    /// <response code="200">CountryResponse></response>
    [ProducesResponseType(typeof(CountryResponse), 200)]
    [HttpGet("{id}")]
    public async Task<CountryResponse> GetCountryById([FromRoute] int id)
    {
        var countries = await countryService.GetCountry(id);
        var response = mapper.Map<CountryResponse>(countries);

        return response;
    }
}
