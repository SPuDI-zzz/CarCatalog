namespace CarCatalog.Api.Controllers.CarsForSale;

using AutoMapper;
using CarCatalog.Api.Controllers.CarsForSale.Models;
using CarCatalog.Services.CarForSale;
using Microsoft.AspNetCore.Mvc;

[Produces("application/json")]
[Route("api/v{version:apiVersion}/carsForSale")]
[ApiController]
[ApiVersion("1.0")]
public class CarsForSaleController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly ICarForSaleService carForSaleService;

    public CarsForSaleController(IMapper mapper, ICarForSaleService carForSaleService)
    {
        this.mapper = mapper;
        this.carForSaleService = carForSaleService;
    }

    [ProducesResponseType(typeof(IEnumerable<CarForSaleResponse>), 200)]
    [HttpGet("")]
    public async Task<IEnumerable<CarForSaleResponse>> GetCarsForSale([FromQuery] int offset = 0, [FromQuery] int limit = 10)
    {
        var carsForSale = await carForSaleService.GetCarsForSale(offset, limit);
        var response = mapper.Map<IEnumerable<CarForSaleResponse>>(carsForSale);

        return response;
    }

    [ProducesResponseType(typeof(CarForSaleResponse), 200)]
    [HttpGet("{id}")]
    public async Task<CarForSaleResponse> GetCarForSaleById([FromRoute] int id)
    {
        var carForSale = await carForSaleService.GetCarForSale(id);
        var response = mapper.Map<CarForSaleResponse>(carForSale);

        return response;
    }
}
