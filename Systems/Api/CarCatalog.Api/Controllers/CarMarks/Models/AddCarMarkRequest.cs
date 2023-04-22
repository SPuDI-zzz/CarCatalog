namespace CarCatalog.Api.Controllers.CarMarks.Models;

using AutoMapper;
using CarCatalog.Services.CarMark;
using FluentValidation;

public class AddCarMarkRequest
{
    public string Name { get; set; } = string.Empty;

    public int IdCountry { get; set; }
}

public class AddCarMarkRequestValidator : AbstractValidator<AddCarMarkRequest>
{
    public AddCarMarkRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is reqired")
            .MaximumLength(50).WithMessage("Name is long")
            ;

        RuleFor(x => x.IdCountry)
            .NotEmpty().WithMessage("IdCountry is reqired")
            ;
    }
}

public class AddCarMarkRequestProfile : Profile
{
    public AddCarMarkRequestProfile()
    {
        CreateMap<AddCarMarkRequest, AddCarMarkModel>();
    }
}
