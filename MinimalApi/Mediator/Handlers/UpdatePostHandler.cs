using Domain.Models;
using MediatR;
using MinimalApi.Mediator.Commands;

namespace MinimalApi.Mediator.Handlers;
public class UpdatePostHandler(IRepository<Post> postRepository) : IRequestHandler<UpdatePost, Post>
{
    public async Task<Post> Handle(UpdatePost request, CancellationToken cancellationToken)
    {
        return await postRepository.UpdateAsync(new Post { Id = request.Id, Content = request.Content });
    }
}