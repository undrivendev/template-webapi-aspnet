using HumbleMediator;
using Microsoft.Extensions.Logging;

namespace WebApiTemplate.Application.Logging;

/// <summary>
/// Decorator for logging command handlers.
/// </summary>
/// <typeparam name="TCommand">The type of the command to handle.</typeparam>
/// <typeparam name="TCommandResult">The type of the command result.</typeparam>
public sealed class CommandHandlerLoggingDecorator<TCommand, TCommandResult>
    : BaseLoggingDecorator<TCommand>,
        ICommandHandler<TCommand, TCommandResult>
    where TCommand : ICommand<TCommandResult>
{
    private readonly ICommandHandler<TCommand, TCommandResult> _decorated;

    /// <summary>
    /// Initializes a new instance of the <see cref="CommandHandlerLoggingDecorator{TCommand, TCommandResult}"/> class.
    /// </summary>
    /// <param name="decorated">The command handler to decorate.</param>
    /// <param name="logger">The logger to use.</param>
    public CommandHandlerLoggingDecorator(
        ICommandHandler<TCommand, TCommandResult> decorated,
        ILogger<CommandHandlerLoggingDecorator<TCommand, TCommandResult>> logger
    )
        : base(logger)
    {
        _decorated = decorated;
    }

    /// <summary>
    /// Handles the command and logs the message.
    /// </summary>
    /// <param name="request">The command to handle.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns></returns>
    public async Task<TCommandResult> Handle(
        TCommand request,
        CancellationToken cancellationToken
    ) => await HandleAndLogMessage(request, cancellationToken, _decorated.Handle);
}
