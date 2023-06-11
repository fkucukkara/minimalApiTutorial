using Domain.Models;
using MinimalApi.Filters;
using MinimalApi.Services;

namespace MinimalApi.Endpoints
{
    public class PostEndPointDefinitions : IEndpointDefiniton
    {
        public void RegisterEndpoints(WebApplication app)
        {
            var post = app.MapGroup("/api/v1/posts");

            post.MapGet("/", GetAllPosts);
            post.MapGet("/{id}", GetPostById).WithName("GetPostById");
            post.MapPost("/", CreatePost).AddEndpointFilter<PostValidationFilter>();
            post.MapPut("/{id}", UpdatePost);
            post.MapDelete("/{id}", DeletePost);
        }

        private async Task<IResult> GetAllPosts(IPostService _postService)
        {
            var posts = await _postService.GetAllPosts();
            return TypedResults.Ok(posts);
        }

        private async Task<IResult> GetPostById(IPostService _postService, int id)
        {
            var post = await _postService.GetPost(id);
            return TypedResults.Ok(post);
        }

        private async Task<IResult> CreatePost(IPostService _postService, Post post)
        {
            var createdPost = await _postService.CreatePost(post);
            return Results.CreatedAtRoute("GetPostById", new { createdPost.Id }, createdPost);
        }

        private async Task<IResult> UpdatePost(IPostService _postService, int id, Post post)
        {
            if (string.IsNullOrEmpty(post.Content))
            { return TypedResults.BadRequest(); }

            var updatedPost = await _postService.UpdatePost(id, post.Content);
            return TypedResults.Ok(updatedPost);
        }

        private async Task<IResult> DeletePost(IPostService _postService, int id)
        {
            await _postService.DeletePost(id);
            return TypedResults.NoContent();
        }
    }
}
