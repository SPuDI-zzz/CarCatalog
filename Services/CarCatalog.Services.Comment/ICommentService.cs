namespace CarCatalog.Services.Comment;

public interface ICommentService
{
    Task<IEnumerable<CommentModel>> GetCommentsByCarForSaleId(int carForSaleId);
    Task<CommentModel> AddComment(AddCommentModel model);
    Task DeleteComment(int commentId);
}
