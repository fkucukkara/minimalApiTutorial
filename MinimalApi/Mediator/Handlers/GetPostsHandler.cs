using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Mediator.Queries;

namespace MinimalApi.Mediator.Handlers
{
    public class GetPostsHandler : IRequestHandler<GetPosts, IList<Post>>
    {
        private readonly IRepository<Post> _postRepository;
        public GetPostsHandler(IRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<IList<Post>> Handle(GetPosts request, CancellationToken cancellationToken)
        {
            return await _postRepository.GetQueryable().ToListAsync();
        }
    }
}
