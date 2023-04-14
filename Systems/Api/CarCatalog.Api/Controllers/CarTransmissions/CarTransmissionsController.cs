namespace CarCatalog.Api.Controllers.CarTransmissions;

using AutoMapper;
using CarCatalog.Api.Controllers.CarTransmissions.Models;
using CarCatalog.Services.CarTransmission;
using Microsoft.AspNetCore.Mvc;

[Produces("application/json")]
[Route("api/v{version:apiVersion}/carTransmissions")]
[ApiController]
[ApiVersion("1.0")]
public class CarTransmissionsController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly ICarTransmissionService carTransmissionService;

    public CarTransmissionsController(IMapper mapper, ICarTransmissionService carTransmissionService)
    {
        this.mapper = mapper;
        this.carTransmissionService = carTransmissionService;
    }

    [ProducesResponseType(typeof(IEnumerable<CarTransmissionResponse>), 200)]
    [HttpGet("")]
    public async Task<IEnumerable<CarTransmissionResponse>> GetCarTransmissions()
    {
        var carTransmissions = await carTransmissionService.GetCarTransmissions();
        var response = mapper.Map<IEnumerable<CarTransmissionResponse>>(carTransmissions);

        return response;
    }

    [ProducesResponseType(typeof(CarTransmissionResponse), 200)]
    [HttpGet("{id}")]
    public async Task<CarTransmissionResponse> GetCarTransmissionById([FromRoute] int id)
    {
        var carTransmission = await carTransmissionService.GetCarTransmission(id);
        var response = mapper.Map<CarTransmissionResponse>(carTransmission);

        return response;
    }
}
