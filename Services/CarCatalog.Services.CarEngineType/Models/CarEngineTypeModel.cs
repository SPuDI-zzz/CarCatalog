namespace CarCatalog.Services.CarEngineType;

using AutoMapper;
using CarCatalog.Context.Entities;

public class CarEngineTypeModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class CarEngineTypeModelProfile : Profile
{
    public CarEngineTypeModelProfile()
    {
        CreateMap<CarEngineType, CarEngineTypeModel>();
    }
}
