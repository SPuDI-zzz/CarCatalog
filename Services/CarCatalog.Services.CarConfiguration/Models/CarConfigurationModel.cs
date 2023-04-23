namespace CarCatalog.Services.CarConfiguration;

using AutoMapper;
using CarCatalog.Context.Entities;
using System.Net;

public class CarConfigurationModel
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

public class CarConfigurationModelProfile : Profile
{
    public CarConfigurationModelProfile()
    {
        CreateMap<CarConfiguration, CarConfigurationModel>()
            .ForMember(dest => dest.CarDriveType, opt => opt.MapFrom(src => src.CarDriveType.Name))
            .ForMember(dest => dest.CarBodyType, opt => opt.MapFrom(src => src.CarBodyType.Name))
            .ForMember(dest => dest.CarEgineType, opt => opt.MapFrom(src => src.CarEgineType.Name))
            .ForMember(dest => dest.CarTransmission, opt => opt.MapFrom(src => src.CarTransmission.Name))
            .ForMember(dest => dest.CarGeneration, opt => opt.MapFrom(src => src.CarGeneration.Name))
            ;
    }
}
