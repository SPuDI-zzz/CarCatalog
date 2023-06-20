﻿namespace CarCatalog.Api.Controllers.CarConfigurations.Models;

using AutoMapper;
using CarCatalog.Services.CarConfiguration;
using FluentValidation;


public class AddCarConfigurationRequest
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

public class AddCarConfigurationRequestValidator : AbstractValidator<AddCarConfigurationRequest>
{
    public AddCarConfigurationRequestValidator()
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

public class AddCarConfigurationRequestProfile : Profile
{
    public AddCarConfigurationRequestProfile()
    {
        CreateMap<AddCarConfigurationRequest, AddCarConfigurationModel>();
    }
}
