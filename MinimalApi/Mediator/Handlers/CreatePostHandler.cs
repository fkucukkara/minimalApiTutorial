using Domain.Models;
using MediatR;
using MinimalApi.Mediator.Commands;

namespace MinimalApi.Mediator.Handlers
{
    public class CreatePostHandler : IRequestHandler<CreatePost, Post>
    {
        private readonly IRepository<Post> _postRepository;
        public CreatePostHandler(IRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Post> Handle(CreatePost request, CancellationToken cancellationToken)
        {
            return await _postRepository.CreateAsync(request.Post);
        }
    }
}
