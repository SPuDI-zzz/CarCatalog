namespace CarCatalog.Services.CarForSale;

using AutoMapper;
using CarCatalog.Context.Entities;
using FluentValidation;

public class AddCarForSaleModel
{
    public string Color { get; set; } = string.Empty;

    public int Price { get; set; }

    public int Mileage { get; set; }

    public int IdCarConfiguration { get; set; }
}

public class AddCarForSaleModelValidator : AbstractValidator<AddCarForSaleModel>
{
    public AddCarForSaleModelValidator()
    {
        RuleFor(x => x.Color)
            .NotEmpty().WithMessage("Name of color is required.")
            .MaximumLength(50).WithMessage("Name of color is long.")
            ;

        RuleFor(x => x.Price)
            .NotEmpty().WithMessage("Price is required.")
            .GreaterThanOrEqualTo(0).WithMessage("Price must be greater than or equal 0.")
            ;

        RuleFor(x => x.Mileage)
            .NotEmpty().WithMessage("Mileage is required.")
            .GreaterThan(0).WithMessage("Mileage must be greater than 0.")
            ;

        RuleFor(x => x.IdCarConfiguration)
            .NotEmpty().WithMessage("IdCarConfiguration is required.")
            ;
    }
}

public class AddCarForSaleModelProfile : Profile
{
    public AddCarForSaleModelProfile()
    {
        CreateMap<AddCarForSaleModel, CarForSale>();
    }
}
