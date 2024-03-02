using Microsoft.Extensions.Logging;

namespace WebApiTemplate.Application.Logging;

public abstract class BaseLoggingDecorator<TRequest>
{
    private readonly ILogger<BaseLoggingDecorator<TRequest>> _logger;

    protected BaseLoggingDecorator(ILogger<BaseLoggingDecorator<TRequest>> logger)
    {
        _logger = logger;
    }

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
