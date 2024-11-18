using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Mediator.Queries;

namespace MinimalApi.Mediator.Handlers;
public class GetPostsHandler(IRepository<Post> postRepository) : IRequestHandler<GetPosts, IEnumerable<Post>>
{
    public async Task<IEnumerable<Post>> Handle(GetPosts request, CancellationToken cancellationToken)
    {
        return await postRepository.GetQueryable().ToListAsync();
    }
}