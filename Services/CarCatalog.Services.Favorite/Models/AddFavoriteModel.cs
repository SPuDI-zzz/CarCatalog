namespace CarCatalog.Services.Favorite;

using AutoMapper;
using CarCatalog.Context.Entities;
using FluentValidation;

public class AddFavoriteModel
{
    public int IdCarForSale { get; set; }

    public int IdUser { get; set; }
}

public class AddFavoriteModelValidator : AbstractValidator<AddFavoriteModel>
{
    public AddFavoriteModelValidator()
    {
        RuleFor(x => x.IdCarForSale)
            .NotEmpty().WithMessage("IdCarForSale is required.")
            ;

        RuleFor(x => x.IdUser)
            .NotEmpty().WithMessage("IdUser is required.")
            ;
    }
}

public class AddFavoriteModelProfile : Profile
{
    public AddFavoriteModelProfile()
    {
        CreateMap<AddFavoriteModel, Favorite>();
    }
}
