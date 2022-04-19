using Microsoft.Extensions.Logging;
using WebApiTemplate.Core.Mediator;

namespace WebApiTemplate.Application;

public class CommandHandlerLoggingDecorator<TCommand, TResult> : ICommandHandler<TCommand, TResult>
    where TCommand : ICommand<TResult>
{
    private readonly ICommandHandler<TCommand, TResult> _decorated;
    private readonly ILogger<CommandHandlerLoggingDecorator<TCommand, TResult>> _logger;

    public CommandHandlerLoggingDecorator(
        ICommandHandler<TCommand, TResult> decorated,
        ILogger<CommandHandlerLoggingDecorator<TCommand, TResult>> logger)
    {
        _decorated = decorated;
        _logger = logger;
    }

    public async Task<TResult> Handle(TCommand command, CancellationToken cancellationToken = default)
    {
        var commandName = typeof(TCommand).Name;
        try
        {
            _logger.LogInformation("Start handling command {Command}", commandName);
            var result = await _decorated.Handle(command, cancellationToken);
            _logger.LogInformation("Finish handling command {Command}", commandName);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error handling command {Command}", commandName);
            throw;
        }
    }
}