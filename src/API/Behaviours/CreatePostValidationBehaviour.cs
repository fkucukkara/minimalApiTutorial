namespace API.Behaviours;
public class CreatePostValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<TRequest> _logger;

    public CreatePostValidationBehaviour(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {

        if (request is CreatePost createPost)
        {
            if (createPost.Post?.Content?.Contains("Invalid", StringComparison.OrdinalIgnoreCase) is true)
            {
                throw new ArgumentException("The post content contains invalid text.", nameof(createPost));
            }
        }

        return next();
    }
}
