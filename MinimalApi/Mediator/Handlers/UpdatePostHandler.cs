using Domain.Models;
using MediatR;
using MinimalApi.Mediator.Commands;

namespace MinimalApi.Mediator.Handlers
{
    public class UpdatePostHandler : IRequestHandler<UpdatePost, Post>
    {
        private readonly IRepository<Post> _postRepository;
        public UpdatePostHandler(IRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Post> Handle(UpdatePost request, CancellationToken cancellationToken)
        {
            return await _postRepository.UpdateAsync(new Post { Id = request.Id, Content = request.Content });
        }
    }
}
