namespace CarCatalog.Api.Controllers.Comments.Models;

using AutoMapper;
using CarCatalog.Services.Comment;

public class CommentResponse
{
    public int Id { get; set; }

    public string Content { get; set; }

    public DateTimeOffset DateTimeAdded { get; set; }

    public int IdCarForSale { get; set; }

    public int IdUser { get; set; }
    public string Name { get; set; }
}

public class CommentResponseProfile : Profile
{
    public CommentResponseProfile()
    {
        CreateMap<CommentModel, CommentResponse>();
    }
}
