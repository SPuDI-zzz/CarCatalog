namespace CarCatalog.Services.CarGeneration;

using AutoMapper;
using CarCatalog.Context.Entities;
using FluentValidation;
using System;

public class UpdateCarGenerationModel
{
    public string Name { get; set; } = string.Empty;

    public int YearBegin { get; set; }

    public int? YearEnd { get; set; }

    public int IDCarModel { get; set; }
}

public class UpdateCarGenerationModelValidator : AbstractValidator<UpdateCarGenerationModel>
{
    public UpdateCarGenerationModelValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(50).WithMessage("Name is long.")
            ;

        RuleFor(x => x.YearBegin)
            .NotEmpty().WithMessage("YearBegin is required.")
            .GreaterThanOrEqualTo(1900).WithMessage("YearBegin must be greater than or equal 1900.")
            .LessThanOrEqualTo(DateTime.Now.Year).WithMessage($"YearBegin must be less than or equal {DateTime.Now.Year}.")
            ;

        RuleFor(x => x.YearEnd)
            .GreaterThanOrEqualTo(x => x.YearBegin).WithMessage(x => $"YearEnd must be greater than or equal YearBegin :{x.YearEnd}.")
            .LessThanOrEqualTo(DateTime.Now.Year).WithMessage($"YearEnd must be less than or equal {DateTime.Now.Year}.")
            ;

        RuleFor(x => x.IDCarModel)
            .NotEmpty().WithMessage("IDCarModel is required.")
            ;
    }
}

public class UpdateCarGenerationModelProfile : Profile
{
    public UpdateCarGenerationModelProfile()
    {
        CreateMap<UpdateCarGenerationModel, CarGeneration>();
    }
}
