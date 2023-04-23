namespace CarCatalog.Api.Controllers.CarGenerations;

using AutoMapper;
using CarCatalog.Api.Controllers.CarGenerations.Models;
using CarCatalog.Common.Security;
using CarCatalog.Services.CarGeneration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Produces("application/json")]
[Route("api/v{version:apiVersion}/carGenerations")]
[ApiController]
[ApiVersion("1.0")]
public class CarGenerationsController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly ICarGenerationService carGenerationService;

    public CarGenerationsController(IMapper mapper, ICarGenerationService carGenerationService)
    {
        this.mapper = mapper;
        this.carGenerationService = carGenerationService;
    }

    [ProducesResponseType(typeof(IEnumerable<CarGenerationResponse>), 200)]
    [HttpGet("")]
    public async Task<IEnumerable<CarGenerationResponse>> GetCarGenerations([FromQuery] CarGenerationRequest request)
    {
        var carGenerations = await carGenerationService.GetCarGenerations(mapper.Map<GetCarGenerationsModel>(request));
        var response = mapper.Map<IEnumerable<CarGenerationResponse>>(carGenerations);

        return response;
    }

    [ProducesResponseType(typeof(CarGenerationResponse), 200)]
    [HttpGet("{id}")]
    public async Task<CarGenerationResponse> GetCarGenerationById([FromRoute] int id)
    {
        var carGeneration = await carGenerationService.GetCarGeneration(id);
        var response = mapper.Map<CarGenerationResponse>(carGeneration);

        return response;
    }

    [HttpPost("")]
    [Authorize(Policy = AppScopes.CarsWrite)]
    public async Task<CarGenerationResponse> AddCarGeneration([FromBody] AddCarGenerationRequest request)
    {
        var model = mapper.Map<AddCarGenerationModel>(request);
        var carGeneration = await carGenerationService.AddCarGeneration(model);
        var response = mapper.Map<CarGenerationResponse>(carGeneration);

        return response;
    }

    [HttpPut("{id}")]
    [Authorize(Policy = AppScopes.CarsWrite)]
    public async Task<IActionResult> UpdateCarGeneration([FromRoute] int id, [FromBody] UpdateCarGenerationRequest request)
    {
        var model = mapper.Map<UpdateCarGenerationModel>(request);
        await carGenerationService.UpdateCarGeneration(id, model);

        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = AppScopes.CarsWrite)]
    public async Task<IActionResult> DeleteCarGeneration([FromRoute] int id)
    {
        await carGenerationService.DeleteCarGeneration(id);

        return Ok();
    }
}
