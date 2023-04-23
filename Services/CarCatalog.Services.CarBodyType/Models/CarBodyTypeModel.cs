namespace CarCatalog.Services.CarBodyType;

using AutoMapper;
using CarCatalog.Context.Entities;

public class CarBodyTypeModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class CarBodyTypeModelProfile : Profile
{
    public CarBodyTypeModelProfile()
    {
        CreateMap<CarBodyType, CarBodyTypeModel>();
    }
}
