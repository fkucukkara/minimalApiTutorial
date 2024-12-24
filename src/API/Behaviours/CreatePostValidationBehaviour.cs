using API.Mediator.Commands;
using MediatR;

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
            if (string.IsNullOrEmpty(createPost?.Post?.Content))
            {
                _logger.LogError($"CreatePost has invalid Content!");
                throw new ArgumentException("CreatePost has invalid Content");
            }
        }

        return next();
    }
}
