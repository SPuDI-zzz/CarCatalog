namespace CarCatalog.Api.Controllers.CarDriveTypes;

using AutoMapper;
using CarCatalog.Api.Controllers.CarDriveTypes.Models;
using CarCatalog.Services.CarDriveType;
using Microsoft.AspNetCore.Mvc;

[Produces("application/json")]
[Route("api/v{version:apiVersion}/carDriveTypes")]
[ApiController]
[ApiVersion("1.0")]
public class CarDriveTypesController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly ICarDriveTypeService carDriveTypeService;

    public CarDriveTypesController(IMapper mapper, ICarDriveTypeService carDriveTypeService)
    {
        this.mapper = mapper;
        this.carDriveTypeService = carDriveTypeService;
    }

    [ProducesResponseType(typeof(IEnumerable<CarDriveTypeResponse>), 200)]
    [HttpGet("")]
    public async Task<IEnumerable<CarDriveTypeResponse>> GetCarDriveTypes([FromQuery] int offset = 0, [FromQuery] int limit = 10)
    {
        var carDriveTypes = await carDriveTypeService.GetCarDriveTypes(offset, limit);
        var response = mapper.Map<IEnumerable<CarDriveTypeResponse>>(carDriveTypes);

        return response;
    }

    /// <summary>
    /// Get car drive type by Id
    /// </summary>
    /// <response code="200">CarDriveTypeResponse></response>
    [ProducesResponseType(typeof(CarDriveTypeResponse), 200)]
    [HttpGet("{id}")]
    public async Task<CarDriveTypeResponse> GetCarDriveTypeById([FromRoute] int id)
    {
        var carDriveType = await carDriveTypeService.GetCarDriveType(id);
        var response = mapper.Map<CarDriveTypeResponse>(carDriveType);

        return response;
    }
}
