namespace CarCatalog.Api.Controllers.Comments;

using AutoMapper;
using CarCatalog.Api.Controllers.Comments.Models;
using CarCatalog.Common.Security;
using CarCatalog.Services.Comment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class CommentsController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly ICommentService commentService;

    public CommentsController(IMapper mapper, ICommentService commentService)
    {
        this.mapper = mapper;
        this.commentService = commentService;
    }

    [ProducesResponseType(typeof(IEnumerable<CommentResponse>), 200)]
    [HttpGet("{userId}")]
    [Authorize(Policy = AppScopes.CommentsWrite)]
    public async Task<IEnumerable<CommentResponse>> GetCommentsByCarForSaleId([FromRoute] int carForSaleId)
    {
        var comments = await commentService.GetCommentsByCarForSaleId(carForSaleId);
        var response = mapper.Map<IEnumerable<CommentResponse>>(comments);

        return response;
    }

    [HttpPost("")]
    [Authorize(Policy = AppScopes.CommentsWrite)]
    public async Task<CommentResponse> AddFavorite([FromBody] AddCommentRequest request)
    {
        var model = mapper.Map<AddCommentModel>(request);
        var comment = await commentService.AddComment(model);
        var response = mapper.Map<CommentResponse>(comment);

        return response;
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = AppScopes.CommentsWrite)]
    public async Task<IActionResult> DeleteFavorite([FromRoute] int id)
    {
        await commentService.DeleteComment(id);

        return Ok();
    }
}
