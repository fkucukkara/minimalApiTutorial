using Domain.Models;
using MediatR;
using MinimalApi.Mediator.Commands;
using MinimalApi.Mediator.Queries;

namespace MinimalApi.Services
{
    public class PostService : IPostService
    {
        private readonly IMediator _mediator;
        public PostService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IList<Post>> GetAllPosts()
        {
            return await _mediator.Send(new GetPosts());
        }

        public async Task<Post> GetPost(int id)
        {
            return await _mediator.Send(new GetPost() { Id = id });
        }

        public async Task<Post> CreatePost(Post post)
        {
            return await _mediator.Send(new CreatePost() { Post = post });
        }

        public async Task<Post> UpdatePost(int id, string content)
        {
            return await _mediator.Send(new UpdatePost() { Id = id, Content = content });
        }

        public async Task DeletePost(int id)
        {
            await _mediator.Send(new DeletePost() { Id = id });
        }
    }
}
