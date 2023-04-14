namespace CarCatalog.Api.Controllers.CarsForSale.Models;

using AutoMapper;
using CarCatalog.Services.CarForSale;
using FluentValidation;

public class CarForSaleRequest
{
    public int Offset { get; set; }
    public int Limit { get; set; } = 10;
}

public class CarForSaleRequestValidator : AbstractValidator<CarForSaleRequest>
{
    public CarForSaleRequestValidator()
    {
        RuleFor(x => x.Offset)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Offset must be greater than or equal 0")
            ;

        RuleFor(x => x.Limit)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Limit must be greater than or equal 0")
            .LessThanOrEqualTo(20)
            .WithMessage("Limit must be less than or equal 100")
            ;
    }
}

public class CarForSaleRequestProfile : Profile
{
    public CarForSaleRequestProfile()
    {
        CreateMap<CarForSaleRequest, GetCarsForSaleModel>();
    }
}
