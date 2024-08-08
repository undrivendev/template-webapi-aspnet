using Microsoft.Extensions.Logging;

namespace WebApiTemplate.Application.Logging;

/// <summary>
/// Base class for logging decorators.
/// </summary>
/// <typeparam name="TRequest"></typeparam>
public abstract class BaseLoggingDecorator<TRequest>
{
    private readonly ILogger<BaseLoggingDecorator<TRequest>> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseLoggingDecorator{TRequest}"/> class.
    /// </summary>
    /// <param name="logger"></param>
    protected BaseLoggingDecorator(ILogger<BaseLoggingDecorator<TRequest>> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Handles and logs the message.
    /// </summary>
    /// <param name="request">The request to handle.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <param name="next">The next delegate to call.</param>
    /// <typeparam name="TResult">The result type of the request.</typeparam>
    /// <returns>The result of the decorated handler.</returns>
    protected async Task<TResult> HandleAndLogMessage<TResult>(
        TRequest request,
        CancellationToken cancellationToken,
        Func<TRequest, CancellationToken, Task<TResult>> next
    )
    {
        _logger.LogInformation("START handling request {@request}", request);
        var result = await next(request, cancellationToken);
        _logger.LogInformation("FINISH handling request {@request}", request);
        return result;
    }
}
