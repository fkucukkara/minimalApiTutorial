using System.Text.RegularExpressions;

namespace API.Filters;
public class PostValidationFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var post = context.GetArgument<Post>(1);

        if (post is not null && post.Content is not null)
        {
            // Define a regular expression to match common special characters
            var specialCharactersPattern = @"[!@#$%^&*()_+={}\[\]:;\""<>,.?/|\\]";

            if (Regex.IsMatch(post.Content!, specialCharactersPattern))
            {
                return await Task.FromResult(Results.BadRequest("Content contains invalid special characters."));
            }
        }

        return await next(context);
    }
}