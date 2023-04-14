namespace CarCatalog.Api.Controllers.CarMarks;

using AutoMapper;
using CarCatalog.Api.Controllers.CarMarks.Models;
using CarCatalog.Services.CarMark;
using Microsoft.AspNetCore.Mvc;

[Produces("application/json")]
[Route("api/v{version:apiVersion}/carMarks")]
[ApiController]
[ApiVersion("1.0")]
public class CarMarksController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly ICarMarkService carMarkService;

    public CarMarksController(IMapper mapper, ICarMarkService carMarkService)
    {
        this.mapper = mapper;
        this.carMarkService = carMarkService;
    }

    [ProducesResponseType(typeof(IEnumerable<CarMarkResponse>), 200)]
    [HttpGet("")]
    public async Task<IEnumerable<CarMarkResponse>> GetCarMarks([FromQuery] CarMarkRequest request)
    {
        var carMarks = await carMarkService.GetCarMarks(mapper.Map<GetCarMarksModel>(request));
        var response = mapper.Map<IEnumerable<CarMarkResponse>>(carMarks);

        return response;
    }

    [ProducesResponseType(typeof(CarMarkResponse), 200)]
    [HttpGet("{id}")]
    public async Task<CarMarkResponse> GetCarDriveTypeById([FromRoute] int id)
    {
        var carMark = await carMarkService.GetCarMark(id);
        var response = mapper.Map<CarMarkResponse>(carMark);

        return response;
    }
}
