namespace CarCatalog.Api.Controllers.CarBodyTypes.Models;

using AutoMapper;
using CarCatalog.Services.CarBodyType;

public class CarBodyTypeResponse
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
}

public class CarBodyTypeResponseProfile : Profile
{
    public CarBodyTypeResponseProfile()
    {
        CreateMap<CarBodyTypeModel, CarBodyTypeResponse>();
    }
}
