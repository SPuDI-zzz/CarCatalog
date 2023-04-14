namespace CarCatalog.Api.Controllers.CarGenerations.Models;

using AutoMapper;
using CarCatalog.Services.CarGeneration;
using FluentValidation;

public class CarGenerationRequest
{
    public int Offset { get; set; }
    public int Limit { get; set; } = 10;
}

public class CarGenerationRequestValidator : AbstractValidator<CarGenerationRequest>
{
    public CarGenerationRequestValidator()
    {
        RuleFor(x => x.Offset)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Offset must be greater than or equal 0")
            ;

        RuleFor(x => x.Limit)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Limit must be greater than or equal 0")
            .LessThanOrEqualTo(20)
            .WithMessage("Limit must be less than or equal 100")
            ;
    }
}

public class CarGenerationRequestProfile : Profile
{
    public CarGenerationRequestProfile()
    {
        CreateMap<CarGenerationRequest, GetCarGenerationsModel>();
    }
}
