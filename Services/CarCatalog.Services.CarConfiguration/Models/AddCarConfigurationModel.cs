namespace CarCatalog.Services.CarConfiguration;

using AutoMapper;
using CarCatalog.Context.Entities;
using FluentValidation;

public class AddCarConfigurationModel
{
    public int Trunk { get; set; }

    public int HorsePower { get; set; }

    public float EngineCapasity { get; set; }

    public bool LeftHandWheel { get; set; }

    public int IdCarDriveType { get; set; }

    public int IdCarBodyType { get; set; }

    public int IdCarEgineType { get; set; }

    public int IdCarTransmission { get; set; }

    public int IdCarGeneration { get; set; }
}

public class AddCarConfigurationModelValidator : AbstractValidator<AddCarConfigurationModel>
{
    public AddCarConfigurationModelValidator()
    {
        RuleFor(x => x.Trunk)
            .GreaterThan(0).WithMessage("Trunk must be greater than 0.")
            ;

        RuleFor(x => x.HorsePower)
            .GreaterThan(0).WithMessage("HorsePower must be greater than 0.")
            ;

        RuleFor(x => x.EngineCapasity)
            .GreaterThan(0).WithMessage("EngineCapasity must be greater than 0.")
            ;

        RuleFor(x => x.IdCarDriveType)
            .NotEmpty().WithMessage("IdCarDriveType is required.")
            ;

        RuleFor(x => x.IdCarTransmission)
            .NotEmpty().WithMessage("IdCarTransmission is required.")
            ;

        RuleFor(x => x.IdCarGeneration)
            .NotEmpty().WithMessage("IdCarGeneration is required.")
            ;

        RuleFor(x => x.IdCarBodyType)
            .NotEmpty().WithMessage("IdCarBodyType is required.")
            ;

        RuleFor(x => x.IdCarEgineType)
            .NotEmpty().WithMessage("IdCarEgineType is required.")
            ;
    }
}

public class AddCarConfigurationModelProfile : Profile
{
    public AddCarConfigurationModelProfile()
    {
        CreateMap<AddCarConfigurationModel, CarConfiguration>();
    }
}
