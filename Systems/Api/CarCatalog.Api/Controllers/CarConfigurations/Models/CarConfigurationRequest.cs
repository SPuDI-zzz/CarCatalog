namespace CarCatalog.Api.Controllers.CarConfigurations.Models;

using AutoMapper;
using CarCatalog.Services.CarConfiguration;
using FluentValidation;

public class CarConfigurationRequest
{
    public int Offset { get; set; }
    public int Limit { get; set; } = 10;
}

public class CarConfigurationRequestValidator : AbstractValidator<CarConfigurationRequest>
{
public CarConfigurationRequestValidator()
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

public class CarConfigurationRequestProfile : Profile
{
    public CarConfigurationRequestProfile()
    {
        CreateMap<CarConfigurationRequest, GetCarConfigurationsModel>();
    }
}
