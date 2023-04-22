namespace CarCatalog.Services.CarMark;

using AutoMapper;
using CarCatalog.Context.Entities;
using FluentValidation;

public class UpdateCarMarkModel
{
    public string Name { get; set; } = string.Empty;

    public int IdCountry { get; set; }
}

public class UpdateCarMarkModelValidator : AbstractValidator<UpdateCarMarkModel>
{
    public UpdateCarMarkModelValidator()
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

public class UpdateCarMarkModelProfile : Profile
{
    public UpdateCarMarkModelProfile()
    {
        CreateMap<UpdateCarMarkModel, CarMark>();
    }
}
