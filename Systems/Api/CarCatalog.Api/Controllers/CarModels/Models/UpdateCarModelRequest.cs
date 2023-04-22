namespace CarCatalog.Api.Controllers.CarModels.Models;

using AutoMapper;
using CarCatalog.Services.CarModel;
using FluentValidation;

public class UpdateCarModelRequest
{
    public string Name { get; set; } = string.Empty;

    public string Class { get; set; } = string.Empty;

    public int IdCarMark { get; set; }
}

public class UpdateCarModelRequestValidator : AbstractValidator<UpdateCarModelRequest>
{
    public UpdateCarModelRequestValidator()
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

public class UpdateCarModelRequestProfile : Profile
{
    public UpdateCarModelRequestProfile()
    {
        CreateMap<UpdateCarModelRequest, UpdateCarModelModel>();
    }
}
