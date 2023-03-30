namespace CarCatalog.Api.Controllers.CarModels.Models;

using AutoMapper;
using CarCatalog.Services.CarModel;

public class CarModelResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public string Class { get; set; } = string.Empty;

    public int IdCarMark { get; set; }
    public string CarMark { get; set; } = string.Empty;
}

public class CarModelResponseProfile : Profile
{
    public CarModelResponseProfile()
    {
        CreateMap<CarModelModel, CarModelResponse>();
    }
}
