namespace CarCatalog.Api.Controllers.CarsFilter.Model;

using AutoMapper;
using CarCatalog.Services.CarFilter;

public class CarFilterResponse
{
    public string CarMarkName { get; set; }
    public string CarModelName { get; set; }
    public string CarGenerationName { get; set; }
    public string CarBodyTypeName { get; set; }
    public string CarDriveTypeName { get; set; }
    public string CarEngineTypeName { get; set; }
    public string CarTransmissionName { get; set; }
    public int CarPrice { get; set; }
}

public class CarFilterResponseProfile : Profile
{
    public CarFilterResponseProfile()
    {
        CreateMap<CarFilterModel, CarFilterResponse>();
    }
}
