using API.Mediator.Commands;
using API.Mediator.Queries;
using Domain.Models;
using MediatR;

namespace API.Services;
public class PostService(IMediator mediator) : IPostService
{
    public async Task<IEnumerable<Post>> GetAllPosts()
    {
        return await mediator.Send(new GetPosts());
    }

    public async Task<Post> GetPost(int id)
    {
        return await mediator.Send(new GetPost() { Id = id });
    }

    public async Task<Post> CreatePost(Post post)
    {
        return await mediator.Send(new CreatePost() { Post = post });
    }

    public async Task<Post> UpdatePost(int id, string content)
    {
        return await mediator.Send(new UpdatePost() { Id = id, Content = content });
    }

    public async Task DeletePost(int id)
    {
        await mediator.Send(new DeletePost() { Id = id });
    }
}