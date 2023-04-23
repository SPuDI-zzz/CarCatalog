namespace CarCatalog.Api.Controllers.CarsForSale;

using AutoMapper;
using CarCatalog.Api.Controllers.CarsForSale.Models;
using CarCatalog.Common.Security;
using CarCatalog.Services.CarForSale;
using Microsoft.AspNetCore.Authorization;
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
    public async Task<IEnumerable<CarForSaleResponse>> GetCarsForSale([FromQuery] CarForSaleRequest request)
    {
        var carsForSale = await carForSaleService.GetCarsForSale(mapper.Map<GetCarsForSaleModel>(request));
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

    [HttpPost("")]
    [Authorize(Policy = AppScopes.CarsWrite)]
    public async Task<CarForSaleResponse> AddCarForSale([FromBody] AddCarForSaleRequest request)
    {
        var model = mapper.Map<AddCarForSaleModel>(request);
        var carForSale = await carForSaleService.AddCarForSale(model);
        var response = mapper.Map<CarForSaleResponse>(carForSale);

        return response;
    }

    [HttpPut("{id}")]
    [Authorize(Policy = AppScopes.CarsWrite)]
    public async Task<IActionResult> UpdateCarForSale([FromRoute] int id, [FromBody] UpdateCarForSaleRequest request)
    {
        var model = mapper.Map<UpdateCarForSaleModel>(request);
        await carForSaleService.UpdateCarForSale(id, model);

        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = AppScopes.CarsWrite)]
    public async Task<IActionResult> DeleteCarForSale([FromRoute] int id)
    {
        await carForSaleService.DeleteCarForSale(id);

        return Ok();
    }
}
