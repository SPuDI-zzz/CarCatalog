namespace CarCatalog.Api.Controllers.CarModels.Models;

using AutoMapper;
using CarCatalog.Services.CarConfiguration;
using FluentValidation;

public class CarModelRequest
{
    public int Offset { get; set; }
    public int Limit { get; set; } = 10;
}

public class CarModelRequestValidator : AbstractValidator<CarModelRequest>
{
    public CarModelRequestValidator()
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

public class CarModelRequestProfile : Profile
{
    public CarModelRequestProfile()
    {
        CreateMap<CarModelRequest, GetCarConfigurationsModel>();
    }
}
