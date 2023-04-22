namespace CarCatalog.Services.CarMark;

using AutoMapper;
using CarCatalog.Context.Entities;
using FluentValidation;

public class AddCarMarkModel
{
    public string Name { get; set; } = string.Empty;

    public int IdCountry { get; set; }
}

public class AddCarMarkModelValidator : AbstractValidator<AddCarMarkModel>
{
    public AddCarMarkModelValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(50).WithMessage("Name is long.")
            ;

        RuleFor(x => x.IdCountry)
            .NotEmpty().WithMessage("IdCountry is required.")
            ;
    }
}

public class AddCarMarkModelProfile : Profile
{
    public AddCarMarkModelProfile()
    {
        CreateMap<AddCarMarkModel, CarMark>();
    }
}
