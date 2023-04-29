namespace CarCatalog.Api.Controllers.CarsFilter.Model;

using AutoMapper;
using CarCatalog.Consts;
using CarCatalog.Services.CarFilter;

public class CarFilterRequest
{
    public int? CarMarkId { get; set; }
    public int? CarModelId { get; set; }
    public int? CarGenerationId { get; set; }
    public int? CarBodyTypeId { get; set; }
    public int? CarDriveTypeId { get; set; }
    public int? CarEngineTypeId { get; set; }
    public int? CarTransmissionTypeId { get; set; }
    public int? CarPrice { get; set; }
    public int? Mileage { get; set; }
    public SortState SortOrder { get; set; }
}

public class CarFilterRequestProfile : Profile
{
    public CarFilterRequestProfile()
    {
        CreateMap<CarFilterRequest, GetCarsFilterModel>();
    }
}
