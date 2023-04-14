namespace CarCatalog.Api.Controllers.CarMarks.Models;

using AutoMapper;
using CarCatalog.Services.CarMark;
using FluentValidation;

public class CarMarkRequest
{
    public int Offset { get; set; }
    public int Limit { get; set; } = 10;
}

public class CarMarkRequestValidator : AbstractValidator<CarMarkRequest>
{
    public CarMarkRequestValidator()
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

public class CarMarkRequestProfile : Profile
{
    public CarMarkRequestProfile()
    {
        CreateMap<CarMarkRequest, GetCarMarksModel>();
    }
}
