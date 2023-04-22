namespace CarCatalog.Api.Controllers.CarModels.Models;

using AutoMapper;
using CarCatalog.Services.CarModel;
using FluentValidation;

public class AddCarModelRequest
{
    public string Name { get; set; } = string.Empty;

    public string Class { get; set; } = string.Empty;

    public int IdCarMark { get; set; }
}

public class AddCarModelRequestValidator : AbstractValidator<AddCarModelRequest>
{
    public AddCarModelRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(50).WithMessage("Name is long.")
            ;

        RuleFor(x => x.Class)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(1).WithMessage("Name is long.")
            ;

        RuleFor(x => x.IdCarMark)
            .NotEmpty().WithMessage("Country is required.")
            ;
    }
}

public class AddCarModelRequestProfile : Profile
{
    public AddCarModelRequestProfile()
    {
        CreateMap<AddCarModelRequest, AddCarModelModel>();
    }
}
