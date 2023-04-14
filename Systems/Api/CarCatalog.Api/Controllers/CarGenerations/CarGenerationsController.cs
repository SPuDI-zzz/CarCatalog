namespace CarCatalog.Api.Controllers.CarGenerations;

using AutoMapper;
using CarCatalog.Api.Controllers.CarGenerations.Models;
using CarCatalog.Services.CarGeneration;
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
}
