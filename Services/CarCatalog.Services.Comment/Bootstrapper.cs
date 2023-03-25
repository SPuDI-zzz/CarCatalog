namespace CarCatalog.Services.Comment;

using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddCommentService(this IServiceCollection services)
    {
        services.AddSingleton<ICommentService, CommentService>();

        return services;
    }
}
