namespace CarCatalog.Services.CarModel;

using FluentValidation;

public class GetCarModelsModel
{
    public int Offset { get; set; }
    public int Limit { get; set; } = 10;

}

public class GetCarModelsModelValidator : AbstractValidator<GetCarModelsModel>
{
    public GetCarModelsModelValidator()
    {
        RuleFor(x => x.Offset)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Offset must be greater than or equal 0.")
            ;

        RuleFor(x => x.Limit)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Limit must be greater than or equal 0.")
            .LessThanOrEqualTo(100)
            .WithMessage("Limit must be less than or equal 100.")
            ;
    }
}

