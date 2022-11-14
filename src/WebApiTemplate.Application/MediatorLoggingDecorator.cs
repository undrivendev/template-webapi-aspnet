using HumbleMediator;
using Microsoft.Extensions.Logging;

namespace WebApiTemplate.Application;

public class MediatorLoggingDecorator : IMediator
{
    private readonly IMediator _decorated;
    private readonly ILogger<IMediator> _logger;

    public MediatorLoggingDecorator(IMediator decorated, ILogger<IMediator> logger)
    {
        _decorated = decorated;
        _logger = logger;
    }

    public async Task<TQueryResult> SendQuery<TQuery, TQueryResult>(
        TQuery query,
        CancellationToken cancellationToken = new()
    ) where TQuery : IQuery<TQueryResult> =>
        await HandleAndLogMessage(
            query,
            cancellationToken,
            _decorated.SendQuery<TQuery, TQueryResult>
        );

    public async Task<TCommandResult> SendCommand<TCommand, TCommandResult>(
        TCommand command,
        CancellationToken cancellationToken = new()
    ) where TCommand : ICommand<TCommandResult> =>
        await HandleAndLogMessage(
            command,
            cancellationToken,
            _decorated.SendCommand<TCommand, TCommandResult>
        );

    private async Task<TResult> HandleAndLogMessage<TRequest, TResult>(
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
