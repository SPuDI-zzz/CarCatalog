namespace CarCatalog.Api.Controllers.CarsFilter.Model;

using AutoMapper;
using CarCatalog.Services.CarFilter;

public class CarFilterRequest
{
    public Guid? CarMarkUid { get; set; }
    public Guid? CarModelUid { get; set; }
    public Guid? CarGenerationUid { get; set; }
    public int? CarBodyTypeId { get; set; }
    public int? CarDriveTypeId { get; set; }
    public int? CarEngineTypeId { get; set; }
    public int? CarTransmissionTypeId { get; set; }
    public int? CarPrice { get; set; }
    public int? Mileage { get; set; }
}

public class CarFilterRequestProfile : Profile
{
    public CarFilterRequestProfile()
    {
        CreateMap<CarFilterRequest, GetCarsFilterModel>();
    }
}
