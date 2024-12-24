using API.Filters;
using API.Services;

namespace API.Endpoints;
public class PostEndPointDefinitions : IEndpointDefiniton
{
    public void RegisterEndpoints(WebApplication app)
    {
        var v1 = app.MapGroup("/api/v1/posts");

        v1.MapGet("/", GetAllPosts);
        v1.MapGet("/{id}", GetPostById);
        v1.MapPost("/", CreatePost).AddEndpointFilter<PostValidationFilter>();
        v1.MapPut("/{id}", UpdatePost);
        v1.MapDelete("/{id}", DeletePost);
    }

    private async Task<IResult> GetAllPosts(IPostService _postService)
    {
        var posts = await _postService.GetAllPosts();
        return TypedResults.Ok(posts);
    }

    private async Task<IResult> GetPostById(IPostService _postService, int id)
    {
        return await _postService.GetPost(id) is Post post
            ? TypedResults.Ok(post)
            : TypedResults.NotFound();
    }

    private async Task<IResult> CreatePost(IPostService _postService, Post post)
    {
        if (string.IsNullOrEmpty(post.Content)) return TypedResults.BadRequest();

        var createdPost = await _postService.CreatePost(post);
        return TypedResults.Created($"/api/v1/posts/{createdPost.Id}", createdPost);
    }

    private async Task<IResult> UpdatePost(IPostService _postService, int id, Post post)
    {
        if (string.IsNullOrEmpty(post.Content)) return TypedResults.BadRequest();

        var existingPost = await _postService.GetPost(id);
        if (existingPost is null) return TypedResults.NotFound();

        await _postService.UpdatePost(id, post.Content);

        return TypedResults.NoContent();
    }

    private async Task<IResult> DeletePost(IPostService _postService, int id)
    {
        if (await _postService.GetPost(id) is not Post post) return TypedResults.NotFound();

        await _postService.DeletePost(id);
        return TypedResults.NoContent();
    }
}