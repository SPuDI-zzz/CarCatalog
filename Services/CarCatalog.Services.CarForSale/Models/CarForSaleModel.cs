namespace CarCatalog.Services.CarForSale;

using AutoMapper;
using CarCatalog.Context.Entities;

public class CarForSaleModel
{
    public int Id { get; set; }
    public string Color { get; set; } = string.Empty;

    public int Price { get; set; }

    public int Mileage { get; set; }

    public int IdCarConfiguration { get; set; }
    public CarConfiguration? CarConfiguration { get; set; }
}

public class CarForSaleProfile : Profile
{
    public CarForSaleProfile()
    {
        CreateMap<CarForSale, CarForSaleModel>()
            .ForMember(dest => dest.CarConfiguration, opt => opt.MapFrom(src => src.CarConfiguration))
            ;
    }
}
