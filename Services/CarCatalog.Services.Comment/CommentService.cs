namespace CarCatalog.Services.Comment;

using AutoMapper;
using CarCatalog.Common.Exceptions;
using CarCatalog.Common.Validator;
using CarCatalog.Context;
using CarCatalog.Context.Entities;
using Microsoft.EntityFrameworkCore;

public class CommentService : ICommentService
{
    private readonly IDbContextFactory<MainDbContext> contextFactory;
    private readonly IMapper mapper;
    private readonly IModelValidator<AddCommentModel> addCommentModelValidator;

    public CommentService(
        IDbContextFactory<MainDbContext> contextFactory
        , IMapper mapper
        , IModelValidator<AddCommentModel> addCommentModelValidator
        )
    {
        this.contextFactory = contextFactory;
        this.mapper = mapper;
        this.addCommentModelValidator = addCommentModelValidator;
    }

    public async Task<IEnumerable<CommentModel>> GetCommentsByCarForSaleId(int carForSaleId)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var comments = context
            .Comments
            .Where(x => x.IdUser.Equals(carForSaleId))
            ;

        var data = (await comments.ToListAsync())
            .Select(mapper.Map<CommentModel>)
            ;

        return data;
    }

    public async Task<CommentModel> AddComment(AddCommentModel model)
    {
        addCommentModelValidator.Check(model);

        using var context = await contextFactory.CreateDbContextAsync();

        var comment = mapper.Map<Comment>(model);
        await context.AddAsync(comment);
        context.SaveChanges();

        return mapper.Map<CommentModel>(comment);
    }

    public async Task DeleteComment(int commentId)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var comment = await context.Comments.FirstOrDefaultAsync(x => x.Id.Equals(commentId))
            ?? throw new ProcessException($"The comment (id : {commentId}) was not found");

        context.Remove(comment);
        context.SaveChanges();
    }
}
