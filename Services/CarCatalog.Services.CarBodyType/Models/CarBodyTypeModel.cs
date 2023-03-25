namespace CarCatalog.Services.CarBodyType;

using AutoMapper;
using CarCatalog.Context.Entities;

public class CarBodyTypeModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class CarBodyTypeProfile : Profile
{
    public CarBodyTypeProfile()
    {
        CreateMap<CarBodyType, CarBodyTypeModel>();
    }
}
