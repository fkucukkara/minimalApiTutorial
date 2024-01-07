using Domain.Models;

namespace MinimalApi.Filters;
public class PostValidationFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var post = context.GetArgument<Post>(1);
        if (post is not null && post.Content is not null && post.Content.Contains('&'))
        {
            return await Task.FromResult(Results.BadRequest());
        }

        return await next(context);
    }
}