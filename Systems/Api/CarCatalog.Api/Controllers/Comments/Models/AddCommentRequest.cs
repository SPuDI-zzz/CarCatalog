namespace CarCatalog.Api.Controllers.Comments.Models;

using AutoMapper;
using CarCatalog.Services.Comment;
using FluentValidation;

public class AddCommentRequest
{
    public string Content { get; set; }

    public int IdCarForSale { get; set; }

    public int IdUser { get; set; }
}

public class AddCommentRequestValidator : AbstractValidator<AddCommentRequest>
{
    public AddCommentRequestValidator()
    {
        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Content is required.")
            .MaximumLength(5000).WithMessage("Content is long.")
            ;

        RuleFor(x => x.IdCarForSale)
            .NotEmpty().WithMessage("IdCarForSale is required.")
            ;

        RuleFor(x => x.IdUser)
            .NotEmpty().WithMessage("IdUser is required.")
            ;
    }
}

public class AddCommentRequestProfile : Profile
{
    public AddCommentRequestProfile()
    {
        CreateMap<AddCommentRequest, AddCommentModel>();
    }
}

