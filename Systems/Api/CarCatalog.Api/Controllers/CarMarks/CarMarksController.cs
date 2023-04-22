namespace CarCatalog.Api.Controllers.CarMarks;

using AutoMapper;
using CarCatalog.Api.Controllers.CarMarks.Models;
using CarCatalog.Common.Security;
using CarCatalog.Services.CarMark;
using Microsoft.AspNetCore.Authorization;
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

    [HttpPost("")]
    [Authorize(Policy = AppScopes.CarsWrite)]
    public async Task<CarMarkResponse> AddCarMark([FromBody] AddCarMarkRequest request)
    {
        var model = mapper.Map<AddCarMarkModel>(request);
        var carMark = await carMarkService.AddCarMark(model);
        var response = mapper.Map<CarMarkResponse>(carMark);

        return response;
    }

    [HttpPut("{id}")]
    [Authorize(Policy = AppScopes.CarsWrite)]
    public async Task<IActionResult> UpdateCarMark([FromRoute] int id, [FromBody] UpdateCarMarkRequest request)
    {
        var model = mapper.Map<UpdateCarMarkModel>(request);
        await carMarkService.UpdateCarMark(id, model);

        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = AppScopes.CarsWrite)]
    public async Task<IActionResult> DeleteCarMark([FromRoute] int id)
    {
        await carMarkService.DeleteCarMark(id);

        return Ok();
    }
}
