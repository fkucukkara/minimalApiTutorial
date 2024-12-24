namespace API.Mediator.Handlers;
public class CreatePostHandler(IRepository<Post> postRepository) : IRequestHandler<CreatePost, Post>
{
    public async Task<Post> Handle(CreatePost request, CancellationToken cancellationToken)
    {
        return await postRepository.CreateAsync(request.Post!);
    }
}