namespace CarCatalog.Services.CarModel;

using AutoMapper;
using CarCatalog.Context.Entities;
using FluentValidation;

public class AddCarModelModel
{
    public string Name { get; set; } = string.Empty;

    public string Class { get; set; } = string.Empty;

    public int IdCarMark { get; set; }
}

public class AddCarModelModelValidator : AbstractValidator<AddCarModelModel>
{
    public AddCarModelModelValidator()
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

public class AddCarModelModelProfile : Profile
{
    public AddCarModelModelProfile()
    {
        CreateMap<AddCarModelModel, CarModel>();
    }
}
