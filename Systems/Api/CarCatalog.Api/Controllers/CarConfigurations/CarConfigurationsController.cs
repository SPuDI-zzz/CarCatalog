namespace CarCatalog.Api.Controllers.CarConfigurations;

using AutoMapper;
using CarCatalog.Api.Controllers.CarConfigurations.Models;
using CarCatalog.Services.CarConfiguration;
using Microsoft.AspNetCore.Mvc;

[Produces("application/json")]
[Route("api/v{version:apiVersion}/carConfigurations")]
[ApiController]
[ApiVersion("1.0")]
public class CarConfigurationsController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly ICarConfigurationService carConfigurationService;

    public CarConfigurationsController(IMapper mapper, ICarConfigurationService carConfigurationService)
    {
        this.mapper = mapper;
        this.carConfigurationService = carConfigurationService;
    }

    [ProducesResponseType(typeof(IEnumerable<CarConfigurationResponse>), 200)]
    [HttpGet("")]
    public async Task<IEnumerable<CarConfigurationResponse>> GetCarConfigurations([FromQuery] CarConfigurationRequest request)
    {
        var carConfigurations = await carConfigurationService.GetCarConfigurations(mapper.Map<GetCarConfigurationsModel>(request));
        var response = mapper.Map<IEnumerable<CarConfigurationResponse>>(carConfigurations);

        return response;
    }

    [ProducesResponseType(typeof(CarConfigurationResponse), 200)]
    [HttpGet("{id}")]
    public async Task<CarConfigurationResponse> GetCarConfigurationById([FromRoute] int id)
    {
        var carConfiguration = await carConfigurationService.GetCarConfiguration(id);
        var response = mapper.Map<CarConfigurationResponse>(carConfiguration);

        return response;
    }
}
