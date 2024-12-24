using API.Mediator.Queries;
using Domain.Models;
using MediatR;

namespace API.Mediator.Handlers;
public class GetPostHandler(IRepository<Post> postRepository) : IRequestHandler<GetPost, Post>
{
    public async Task<Post> Handle(GetPost request, CancellationToken cancellationToken)
    {
        return await postRepository.GetByIdAsync(request.Id);
    }
}