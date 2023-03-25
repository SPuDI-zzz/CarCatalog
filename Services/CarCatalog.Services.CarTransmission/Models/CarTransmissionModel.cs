namespace CarCatalog.Services.CarTransmission;

using AutoMapper;
using CarCatalog.Context.Entities;

public class CarTransmissionModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class CarTransmissionProfile : Profile
{
    public CarTransmissionProfile()
    {
        CreateMap<CarTransmission, CarTransmissionModel>();
    }
}
