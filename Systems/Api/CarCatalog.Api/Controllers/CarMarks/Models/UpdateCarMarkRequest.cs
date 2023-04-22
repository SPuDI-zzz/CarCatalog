namespace CarCatalog.Api.Controllers.CarMarks.Models;

using AutoMapper;
using CarCatalog.Services.CarMark;
using FluentValidation;

public class UpdateCarMarkRequest
{
    public string Name { get; set; } = string.Empty;

    public int IdCountry { get; set; }
}

public class UpdateCarMarkRequestValidator : AbstractValidator<UpdateCarMarkRequest>
{
    public UpdateCarMarkRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is reqired.")
            .MaximumLength(50).WithMessage("Name is long.")
            ;

        RuleFor(x => x.IdCountry)
            .NotEmpty().WithMessage("IdCountry is required.");
    }
}

public class UpdateCarMarkRequestProfile : Profile
{
    public UpdateCarMarkRequestProfile()
    {
        CreateMap<UpdateCarMarkRequest, UpdateCarMarkModel>();
    }
}
