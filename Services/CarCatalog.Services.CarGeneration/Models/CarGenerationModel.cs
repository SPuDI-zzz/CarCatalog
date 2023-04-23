namespace CarCatalog.Services.CarGeneration;

using AutoMapper;
using CarCatalog.Context.Entities;

public class CarGenerationModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public int YearBegin { get; set; }

    public int YearEnd { get; set; }

    public int IDCarModel { get; set; }
    public string CarModel { get; set; } = string.Empty;
}

public class CarGenerationModelProfile : Profile
{
    public CarGenerationModelProfile()
    {
        CreateMap<CarGeneration, CarGenerationModel>()
            .ForMember(dest => dest.CarModel, opt => opt.MapFrom(src => src.CarModel.Name))
            ;
    }
}
