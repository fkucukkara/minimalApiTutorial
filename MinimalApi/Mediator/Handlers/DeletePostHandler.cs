using Domain.Models;
using MediatR;
using MinimalApi.Mediator.Commands;

namespace MinimalApi.Mediator.Handlers;
public class DeletePostHandler(IRepository<Post> postRepository) : IRequestHandler<DeletePost>
{
    public async Task Handle(DeletePost request, CancellationToken cancellationToken)
    {
        await postRepository.DeleteAsync(request.Id);
    }
}