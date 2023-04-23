namespace CarCatalog.Services.CarModel;

using AutoMapper;
using CarCatalog.Context.Entities;
using FluentValidation;

public class UpdateCarModelModel
{
    public string Name { get; set; } = string.Empty;

    public string Class { get; set; } = string.Empty;

    public int IdCarMark { get; set; }
}

public class UpdateCarModelModelValidator : AbstractValidator<UpdateCarModelModel>
{
    public UpdateCarModelModelValidator()
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
            .NotEmpty().WithMessage("IdCarMark is required.")
            ;
    }
}

public class UpdateCarModelModelProfile : Profile
{
    public UpdateCarModelModelProfile()
    {
        CreateMap<UpdateCarModelModel, CarModel>();
    }
}
