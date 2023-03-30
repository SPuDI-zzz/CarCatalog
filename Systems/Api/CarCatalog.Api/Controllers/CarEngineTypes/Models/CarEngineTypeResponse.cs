namespace CarCatalog.Api.Controllers.CarEngineTypes.Models;

using AutoMapper;
using CarCatalog.Services.CarEngineType;

public class CarEngineTypeResponse
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
}

public class CarEngineTypeResponseProfile : Profile
{
    public CarEngineTypeResponseProfile()
    {
        CreateMap<CarEngineTypeModel, CarEngineTypeResponse>();
    }
}
