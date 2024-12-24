using API.Mediator.Queries;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Mediator.Handlers;
public class GetPostsHandler(IRepository<Post> postRepository) : IRequestHandler<GetPosts, IEnumerable<Post>>
{
    public async Task<IEnumerable<Post>> Handle(GetPosts request, CancellationToken cancellationToken)
    {
        return await postRepository.GetQueryable().ToListAsync();
    }
}