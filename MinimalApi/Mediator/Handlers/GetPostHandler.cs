using Domain.Models;
using MediatR;
using MinimalApi.Mediator.Queries;

namespace MinimalApi.Mediator.Handlers;
public class GetPostHandler(IRepository<Post> postRepository) : IRequestHandler<GetPost, Post>
{
    public async Task<Post> Handle(GetPost request, CancellationToken cancellationToken)
    {
        return await postRepository.GetByIdAsync(request.Id);
    }
}