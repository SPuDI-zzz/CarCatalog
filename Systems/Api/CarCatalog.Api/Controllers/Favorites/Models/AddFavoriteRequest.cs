namespace CarCatalog.Api.Controllers.Favorites.Models;

using AutoMapper;
using CarCatalog.Services.Favorite;
using FluentValidation;

public class AddFavoriteRequest
{
    public int IdCarForSale { get; set; }

    public int IdUser { get; set; }
}

public class AddFavoriteRequestValidator : AbstractValidator<AddFavoriteRequest>
{
    public AddFavoriteRequestValidator()
    {
        RuleFor(x => x.IdCarForSale)
            .NotEmpty().WithMessage("IdCarForSale is required.")
            ;

        RuleFor(x => x.IdUser)
            .NotEmpty().WithMessage("IdUser is required.")
            ;
    }
}

public class AddFavoriteRequestProfile : Profile
{
    public AddFavoriteRequestProfile()
    {
        CreateMap<AddFavoriteRequest, AddFavoriteModel>();
    }
}
