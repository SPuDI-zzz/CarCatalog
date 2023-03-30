namespace CarCatalog.Api.Controllers.CarConfigurations.Models;

using AutoMapper;
using CarCatalog.Services.CarConfiguration;

public class CarConfigurationResponse
{
    public int Id { get; set; }
    public int Trunk { get; set; }

    public int HorsePower { get; set; }

    public float EngineCapasity { get; set; }

    public bool LeftHandWheel { get; set; }

    public int IdCarDriveType { get; set; }
    public string CarDriveType { get; set; } = string.Empty;

    public int IdCarBodyType { get; set; }
    public string CarBodyType { get; set; } = string.Empty;

    public int IdCarEgineType { get; set; }
    public string CarEgineType { get; set; } = string.Empty;

    public int IdCarTransmission { get; set; }
    public string CarTransmission { get; set; } = string.Empty;

    public int IdCarGeneration { get; set; }
    public string CarGeneration { get; set; } = string.Empty;
}

public class CarConfigurationResponseProfile : Profile
{
    public CarConfigurationResponseProfile()
    {
        CreateMap<CarConfigurationModel, CarConfigurationResponse>()
            .ForMember(dest => dest.CarDriveType, opt => opt.MapFrom(src => src.CarDriveType))
            .ForMember(dest => dest.CarBodyType, opt => opt.MapFrom(src => src.CarBodyType))
            .ForMember(dest => dest.CarEgineType, opt => opt.MapFrom(src => src.CarEgineType))
            .ForMember(dest => dest.CarTransmission, opt => opt.MapFrom(src => src.CarTransmission))
            .ForMember(dest => dest.CarGeneration, opt => opt.MapFrom(src => src.CarGeneration))
            ;
    }
}
