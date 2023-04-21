namespace CarCatalog.Api.Controllers.CarsFilter.Model;

using AutoMapper;
using CarCatalog.Services.CarFilter;

public class CarFilterRequest
{
    public Guid? CarMarkUid { get; set; } = null;
    public Guid? CarModelUid { get; set; } = null;
    public Guid? CarGenerationUid { get; set; } = null;
    public int? CarBodyTypeId { get; set; } = null;
    public int? CarDriveTypeId { get; set; } = null;
    public int? CarEngineTypeId { get; set; } = null;
    public int? CarTransmissionTypeId { get; set; } = null;
    public int? CarPrice { get; set; } = null;
}

public class CarFilterRequestProfile : Profile
{
    public CarFilterRequestProfile()
    {
        CreateMap<CarFilterRequest, GetCarsFilterModel>();
    }
}
