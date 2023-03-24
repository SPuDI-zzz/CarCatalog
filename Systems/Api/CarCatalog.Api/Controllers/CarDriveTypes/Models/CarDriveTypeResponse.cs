namespace CarCatalog.Api.Controllers.CarDriveTypes.Models;

using AutoMapper;
using CarCatalog.Services.CarDriveType;

public class CarDriveTypeResponse
{
    /// <summary>
    /// CarDriveType Id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// CarDriveType name
    /// </summary>
    public string Name { get; set; } = string.Empty;
}

public class CarDriveTypeResponseProfile : Profile
{
    public CarDriveTypeResponseProfile()
    {
        CreateMap<CarDriveTypeModel, CarDriveTypeResponse>();
    }
}
