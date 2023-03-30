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
    public async Task<IEnumerable<CarTransmissionResponse>> GetCarTransmissions([FromQuery] int offset = 0, [FromQuery] int limit = 10)
    {
        var carTransmissions = await carTransmissionService.GetCarTransmissions(offset, limit);
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
