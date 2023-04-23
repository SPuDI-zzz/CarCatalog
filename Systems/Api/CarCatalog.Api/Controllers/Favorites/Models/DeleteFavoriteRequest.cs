namespace CarCatalog.Api.Controllers.Favorites.Models;

using AutoMapper;
using CarCatalog.Services.Favorite;
using FluentValidation;

public class DeleteFavoriteRequest
{
    public int IdCarForSale { get; set; }

    public int IdUser { get; set; }
}

public class DeleteFavoriteRequestValidator : AbstractValidator<DeleteFavoriteRequest>
{
    public DeleteFavoriteRequestValidator()
    {
        RuleFor(x => x.IdCarForSale)
            .NotEmpty().WithMessage("IdCarForSale is required.")
            ;

        RuleFor(x => x.IdUser)
            .NotEmpty().WithMessage("IdUser is required.")
            ;
    }
}

public class DeleteFavoriteRequestProfile : Profile
{
    public DeleteFavoriteRequestProfile()
    {
        CreateMap<DeleteFavoriteRequest, DeleteFavoriteModel>();
    }
}
