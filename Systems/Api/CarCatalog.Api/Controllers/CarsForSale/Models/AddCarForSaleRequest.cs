﻿namespace CarCatalog.Api.Controllers.CarsForSale.Models;

using AutoMapper;
using CarCatalog.Services.CarForSale;
using FluentValidation;

public class AddCarForSaleRequest
{
    public string Color { get; set; } = string.Empty;

    public int Price { get; set; }

    public int Mileage { get; set; }

    public int IdCarConfiguration { get; set; }
}

public class AddCarForSaleRequestValidator : AbstractValidator<AddCarForSaleRequest>
{
    public AddCarForSaleRequestValidator()
    {
        RuleFor(x => x.Color)
            .NotEmpty().WithMessage("Name of color is required.")
            .MaximumLength(50).WithMessage("Name of color is long.")
            ;

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0.")
            ;

        RuleFor(x => x.Mileage)
            .GreaterThanOrEqualTo(0).WithMessage("Mileage must be greater than or equal 0.")
            ;

        RuleFor(x => x.IdCarConfiguration)
            .NotEmpty().WithMessage("IdCarConfiguration is required.")
            ;
    }
}

public class AddCarForSaleRequestProfile : Profile
{
    public AddCarForSaleRequestProfile()
    {
        CreateMap<AddCarForSaleRequest, AddCarForSaleModel>();
    }
}
