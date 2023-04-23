namespace CarCatalog.Services.Comment;

using AutoMapper;
using CarCatalog.Context.Entities;
using FluentValidation;
using System;

public class AddCommentModel
{
    public string Content { get; set; }

    public int IdCarForSale { get; set; }

    public int IdUser { get; set; }
}

public class AddCommentModelValidator : AbstractValidator<AddCommentModel>
{
    public AddCommentModelValidator()
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

public class AddCommentModelProfile : Profile
{
    public AddCommentModelProfile()
    {
        CreateMap<AddCommentModel, Comment>()
            .ForMember(dest => dest.DateTimeAdded, opt => opt.MapFrom(x => DateTimeOffset.UtcNow))
            ;
    }
}
