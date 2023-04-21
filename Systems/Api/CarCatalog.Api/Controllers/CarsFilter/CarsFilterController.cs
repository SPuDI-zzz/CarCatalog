namespace CarCatalog.Api.Controllers.CarsFilter;

using AutoMapper;
using CarCatalog.Api.Controllers.CarsFilter.Model;
using CarCatalog.Services.CarFilter;
using Microsoft.AspNetCore.Mvc;

[Produces("application/json")]
[Route("api/v{version:apiVersion}/carsFilter")]
[ApiController]
[ApiVersion("1.0")]
public class CarsFilterController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly ICarFilterService carFilterService;

    public CarsFilterController(IMapper mapper, ICarFilterService carFilterService)
    {
        this.mapper = mapper;
        this.carFilterService = carFilterService;
    }

    [ProducesResponseType(typeof(IEnumerable<CarFilterResponse>), 200)]
    [HttpGet("")]
    public async Task<IEnumerable<CarFilterResponse>> GetCarsFilter([FromQuery] CarFilterRequest request)
    {
        var carsForSale = await carFilterService.Index(mapper.Map<GetCarsFilterModel>(request));
        var response = mapper.Map<IEnumerable<CarFilterResponse>>(carsForSale);

        return response;
    }
}
