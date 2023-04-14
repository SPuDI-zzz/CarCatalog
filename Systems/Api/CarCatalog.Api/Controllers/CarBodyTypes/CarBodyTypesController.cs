namespace CarCatalog.Api.Controllers.CarBodyTypes;

using AutoMapper;
using CarCatalog.Api.Controllers.CarBodyTypes.Models;
using CarCatalog.Services.CarBodyType;
using Microsoft.AspNetCore.Mvc;

[Produces("application/json")]
[Route("api/v{version:apiVersion}/carBodyTypes")]
[ApiController]
[ApiVersion("1.0")]
public class CarBodyTypesController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly ICarBodyTypeService carBodyTypeService;

    public CarBodyTypesController(IMapper mapper, ICarBodyTypeService carBodyTypeService)
    {
        this.mapper = mapper;
        this.carBodyTypeService = carBodyTypeService;
    }

    [ProducesResponseType(typeof(IEnumerable<CarBodyTypeResponse>), 200)]
    [HttpGet("")]
    public async Task<IEnumerable<CarBodyTypeResponse>> GetCarBodyTypes()
    {
        var carBodyTypes = await carBodyTypeService.GetCarBodyTypes();
        var response = mapper.Map<IEnumerable<CarBodyTypeResponse>>(carBodyTypes);

        return response;
    }

    [ProducesResponseType(typeof(CarBodyTypeResponse), 200)]
    [HttpGet("{id}")]
    public async Task<CarBodyTypeResponse> GetCarBodyTypeById([FromRoute] int id)
    {
        var carBodyType = await carBodyTypeService.GetCarBodyType(id);
        var response = mapper.Map<CarBodyTypeResponse>(carBodyType);

        return response;
    }
}
