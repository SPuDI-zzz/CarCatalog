namespace CarCatalog.Services.CarForSale;

using AutoMapper;
using CarCatalog.Context.Entities;

public class CarForSaleModel
{
    public int Id { get; set; }
    public string Color { get; set; } = string.Empty;

    public int Price { get; set; }

    public int Mileage { get; set; }

    public bool IsSold { get; set; }

    public int IdCarConfiguration { get; set; }
}

public class CarForSaleModelProfile : Profile
{
    public CarForSaleModelProfile()
    {
        CreateMap<CarForSale, CarForSaleModel>();
    }
}
