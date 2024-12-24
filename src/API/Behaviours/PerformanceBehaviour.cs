using System.Diagnostics;

namespace API.Behaviours;
public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly Stopwatch _sw;
    private readonly ILogger<TRequest> _logger;
    public PerformanceBehaviour(ILogger<TRequest> logger)
    {
        _sw = new Stopwatch();
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _sw.Start();
        var response = await next();
        _sw.Stop();

        string message = $"Request: {typeof(TRequest).Name}, ElapsedInMiliseconds: {_sw.ElapsedMilliseconds}";
        _logger.LogInformation(message);
        return response;
    }
}
