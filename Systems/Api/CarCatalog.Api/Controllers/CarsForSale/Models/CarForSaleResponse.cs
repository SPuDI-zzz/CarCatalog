namespace CarCatalog.Api.Controllers.CarsForSale.Models;

using AutoMapper;
using CarCatalog.Services.CarForSale;

public class CarForSaleResponse
{
    public int Id { get; set; }
    public string Color { get; set; } = string.Empty;

    public int Price { get; set; }

    public int Mileage { get; set; }

    public int IdCarConfiguration { get; set; }
}

public class CarForSaleResponseProfile : Profile
{
    public CarForSaleResponseProfile()
    {
        CreateMap<CarForSaleModel, CarForSaleResponse>();
    }
}
