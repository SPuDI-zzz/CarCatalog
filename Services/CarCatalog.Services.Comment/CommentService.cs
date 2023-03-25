namespace CarCatalog.Services.Comment;

using AutoMapper;
using CarCatalog.Context;
using Microsoft.EntityFrameworkCore;

public class CommentService : ICommentService
{
    private readonly IDbContextFactory<MainDbContext> contextFactory;
    private readonly IMapper mapper;

    public CommentService(IDbContextFactory<MainDbContext> contextFactory, IMapper mapper)
    {
        this.contextFactory = contextFactory;
        this.mapper = mapper;
    }
}
