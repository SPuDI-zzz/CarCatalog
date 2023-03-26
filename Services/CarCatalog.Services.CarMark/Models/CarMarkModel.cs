namespace CarCatalog.Services.CarMark;

using AutoMapper;
using CarCatalog.Context.Entities;


public class CarMarkModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public int IdCountry { get; set; }
    public string Country { get; set; } = string.Empty;
}

public class CarMarkProfile : Profile
{
    public CarMarkProfile()
    {
        CreateMap<CarMark, CarMarkModel>()
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country.Name))
            ;
    }
}
