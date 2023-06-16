using Domain.Models;
using MediatR;
using MinimalApi.Mediator.Commands;

namespace MinimalApi.Mediator.Handlers;
public class DeletePostHandler : IRequestHandler<DeletePost>
{
    private readonly IRepository<Post> _postRepository;
    public DeletePostHandler(IRepository<Post> postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task Handle(DeletePost request, CancellationToken cancellationToken)
    {
        await _postRepository.DeleteAsync(request.Id);
    }
}