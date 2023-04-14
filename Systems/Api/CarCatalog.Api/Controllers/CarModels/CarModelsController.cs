namespace CarCatalog.Api.Controllers.CarModels;

using AutoMapper;
using CarCatalog.Api.Controllers.CarModels.Models;
using CarCatalog.Services.CarModel;
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
}
