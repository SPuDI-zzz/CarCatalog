namespace CarCatalog.Services.CarConfiguration;

using AutoMapper;
using CarCatalog.Context.Entities;
using FluentValidation;

public class UpdateCarConfigurationModel
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

public class UpdateCarConfigurationModelValidator : AbstractValidator<UpdateCarConfigurationModel>
{
    public UpdateCarConfigurationModelValidator()
    {
        RuleFor(x => x.Trunk)
            .NotEmpty().WithMessage("Trunk is required.")
            .GreaterThan(0).WithMessage("Trunk must be greater than 0.")
            ;

        RuleFor(x => x.HorsePower)
            .NotEmpty().WithMessage("HorsePower is required.")
            .GreaterThan(0).WithMessage("HorsePower must be greater than 0.")
            ;

        RuleFor(x => x.EngineCapasity)
            .NotEmpty().WithMessage("EngineCapasity is required.")
            .GreaterThan(0).WithMessage("EngineCapasity must be greater than 0.")
            ;

        RuleFor(x => x.LeftHandWheel)
            .NotEmpty().WithMessage("Trunk is required.")
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

public class UpdateCarConfigurationModelProfile : Profile
{
    public UpdateCarConfigurationModelProfile()
    {
        CreateMap<UpdateCarConfigurationModel, CarConfiguration>();
    }
}
