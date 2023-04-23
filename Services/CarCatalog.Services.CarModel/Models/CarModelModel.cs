namespace CarCatalog.Services.CarModel;

using AutoMapper;
using CarCatalog.Context.Entities;

public class CarModelModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public string Class { get; set; } = string.Empty;

    public int IdCarMark { get; set; }
    public string CarMark { get; set; } = string.Empty;
}

public class CarModelModelProfile : Profile
{
    public CarModelModelProfile()
    {
        CreateMap<CarModel, CarModelModel>()
            .ForMember(dest => dest.CarMark, opt => opt.MapFrom(src => src.CarMark.Name))
            ;
    }
}
