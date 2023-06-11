using Domain.Models;
using MediatR;
using MinimalApi.Mediator.Queries;

namespace MinimalApi.Mediator.Handlers
{
    public class GetPostHandler : IRequestHandler<GetPost, Post>
    {
        private readonly IRepository<Post> _postRepository;
        public GetPostHandler(IRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Post> Handle(GetPost request, CancellationToken cancellationToken)
        {
            return await _postRepository.GetByIdAsync(request.Id);
        }
    }
}
