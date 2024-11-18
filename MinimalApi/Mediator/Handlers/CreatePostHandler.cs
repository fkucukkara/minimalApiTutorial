using Domain.Models;
using MediatR;
using MinimalApi.Mediator.Commands;

namespace MinimalApi.Mediator.Handlers;
public class CreatePostHandler(IRepository<Post> postRepository) : IRequestHandler<CreatePost, Post>
{
    public async Task<Post> Handle(CreatePost request, CancellationToken cancellationToken)
    {
        return await postRepository.CreateAsync(request.Post!);
    }
}