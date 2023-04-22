namespace CarCatalog.Api.Controllers.CarModels;

using AutoMapper;
using CarCatalog.Api.Controllers.CarModels.Models;
using CarCatalog.Common.Security;
using CarCatalog.Services.CarModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Produces("application/json")]
[Route("api/v{version:apiVersion}/carModels")]
[ApiController]
[ApiVersion("1.0")]
public class CarModelsController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly ICarModelService carModelService;

    public CarModelsController(IMapper mapper, ICarModelService carModelService)
    {
        this.mapper = mapper;
        this.carModelService = carModelService;
    }

    [ProducesResponseType(typeof(IEnumerable<CarModelResponse>), 200)]
    [HttpGet("")]
    public async Task<IEnumerable<CarModelResponse>> GetCarModels([FromQuery] CarModelRequest request)
    {
        var carModels = await carModelService.GetCarModels(mapper.Map<GetCarModelsModel>(request));
        var response = mapper.Map<IEnumerable<CarModelResponse>>(carModels);

        return response;
    }

    [ProducesResponseType(typeof(CarModelResponse), 200)]
    [HttpGet("{id}")]
    public async Task<CarModelResponse> GetCarModelById([FromRoute] int id)
    {
        var CarModel = await carModelService.GetCarModel(id);
        var response = mapper.Map<CarModelResponse>(CarModel);

        return response;
    }

    [HttpPost("")]
    [Authorize(Policy = AppScopes.CarsWrite)]
    public async Task<CarModelResponse> AddCarModel([FromBody] AddCarModelRequest request)
    {
        var model = mapper.Map<AddCarModelModel>(request);
        var carMark = await carModelService.AddCarModel(model);
        var response = mapper.Map<CarModelResponse>(carMark);

        return response;
    }

    [HttpPut("{id}")]
    [Authorize(Policy = AppScopes.CarsWrite)]
    public async Task<IActionResult> UpdateCarModel([FromRoute] int id, [FromBody] UpdateCarModelRequest request)
    {
        var model = mapper.Map<UpdateCarModelModel>(request);
        await carModelService.UpdateCarModel(id, model);

        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = AppScopes.CarsWrite)]
    public async Task<IActionResult> DeleteCarModel([FromRoute] int id)
    {
        await carModelService.DeleteCarModel(id);

        return Ok();
    }
}
