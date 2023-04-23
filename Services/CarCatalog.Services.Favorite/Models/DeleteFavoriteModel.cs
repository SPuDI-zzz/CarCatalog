namespace CarCatalog.Services.Favorite;

using FluentValidation;

public class DeleteFavoriteModel
{
    public int IdCarForSale { get; set; }

    public int IdUser { get; set; }
}

public class DeleteFavoriteModelValidator : AbstractValidator<DeleteFavoriteModel>
{
    public DeleteFavoriteModelValidator()
    {
        RuleFor(x => x.IdCarForSale)
            .NotEmpty().WithMessage("IdCarForSale is required.")
            ;

        RuleFor(x => x.IdUser)
            .NotEmpty().WithMessage("IdUser is required.")
            ;
    }
}
