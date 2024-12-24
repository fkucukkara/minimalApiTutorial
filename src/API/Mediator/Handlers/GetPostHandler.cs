using API.Mediator.Queries;

namespace API.Mediator.Handlers;
public class GetPostHandler(IRepository<Post> postRepository) : IRequestHandler<GetPost, Post>
{
    public async Task<Post> Handle(GetPost request, CancellationToken cancellationToken)
    {
        return await postRepository.GetByIdAsync(request.Id);
    }
}