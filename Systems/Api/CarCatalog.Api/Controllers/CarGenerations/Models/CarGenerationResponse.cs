namespace CarCatalog.Api.Controllers.CarGenerations.Models;

using AutoMapper;
using CarCatalog.Services.CarGeneration;

public class CarGenerationResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public int YearBegin { get; set; }

    public int YearEnd { get; set; }

    public int IDCarModel { get; set; }
    public string CarModel { get; set; } = string.Empty;
}

public class CarGenerationResponseProfile : Profile
{
    public CarGenerationResponseProfile()
    {
        CreateMap<CarGenerationModel, CarGenerationResponse>();
    }
}
