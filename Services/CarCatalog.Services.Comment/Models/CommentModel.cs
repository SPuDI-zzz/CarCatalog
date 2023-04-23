namespace CarCatalog.Services.Comment;

using AutoMapper;
using CarCatalog.Context.Entities;

public class CommentModel
{
    public int Id { get; set; }

    public string Content { get; set; }

    public DateTimeOffset DateTimeAdded { get; set; }

    public int IdCarForSale { get; set; }

    public int IdUser { get; set; }
    public string Name { get; set; }
}

public class CommentModelProfile : Profile
{
    public CommentModelProfile()
    {
        CreateMap<Comment, CommentModel>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.User.UserName))
            ;
    }
}
