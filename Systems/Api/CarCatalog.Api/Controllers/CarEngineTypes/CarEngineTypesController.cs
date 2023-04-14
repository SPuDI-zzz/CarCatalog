namespace CarCatalog.Api.Controllers.CarEngineTypes;

using AutoMapper;
using CarCatalog.Api.Controllers.CarEngineTypes.Models;
using CarCatalog.Services.CarEngineType;
using Microsoft.AspNetCore.Mvc;

[Produces("application/json")]
[Route("api/v{version:apiVersion}/carEngineTypes")]
[ApiController]
[ApiVersion("1.0")]
public class CarEngineTypesController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly ICarEngineTypeService carEngineTypeService;

    public CarEngineTypesController(IMapper mapper, ICarEngineTypeService carEngineTypeService)
    {
        this.mapper = mapper;
        this.carEngineTypeService = carEngineTypeService;
    }

    [ProducesResponseType(typeof(IEnumerable<CarEngineTypeResponse>), 200)]
    [HttpGet("")]
    public async Task<IEnumerable<CarEngineTypeResponse>> GetCarEngineTypes()
    {
        var carEngineTypes = await carEngineTypeService.GetCarEngineTypes();
        var response = mapper.Map<IEnumerable<CarEngineTypeResponse>>(carEngineTypes);

        return response;
    }

    [ProducesResponseType(typeof(CarEngineTypeResponse), 200)]
    [HttpGet("{id}")]
    public async Task<CarEngineTypeResponse> GetCarEngineTypeById([FromRoute] int id)
    {
        var carEngineType = await carEngineTypeService.GetCarEngineType(id);
        var response = mapper.Map<CarEngineTypeResponse>(carEngineType);

        return response;
    }
}
