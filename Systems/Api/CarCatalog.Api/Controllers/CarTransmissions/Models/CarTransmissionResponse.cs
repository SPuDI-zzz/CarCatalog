namespace CarCatalog.Api.Controllers.CarTransmissions.Models;

using AutoMapper;
using CarCatalog.Services.CarTransmission;

public class CarTransmissionResponse
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
}

public class CarTransmissionResponseProfile : Profile
{
    public CarTransmissionResponseProfile()
    {
        CreateMap<CarTransmissionModel, CarTransmissionResponse>();
    }
}
