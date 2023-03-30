namespace CarCatalog.Api.Controllers.CarMarks.Models;

using AutoMapper;
using CarCatalog.Services.CarMark;

public class CarMarkResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public int IdCountry { get; set; }
    public string Country { get; set; } = string.Empty;
}

public class CarMarkResponseProfile : Profile
{
    public CarMarkResponseProfile()
    {
        CreateMap <CarMarkModel, CarMarkResponse>();
    }
}
