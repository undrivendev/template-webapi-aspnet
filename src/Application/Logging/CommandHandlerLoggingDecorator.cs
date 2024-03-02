using HumbleMediator;
using Microsoft.Extensions.Logging;

namespace WebApiTemplate.Application.Logging;

public sealed class CommandHandlerLoggingDecorator<TCommand, TCommandResult>
    : BaseLoggingDecorator<TCommand>,
        ICommandHandler<TCommand, TCommandResult>
    where TCommand : ICommand<TCommandResult>
{
    private readonly ICommandHandler<TCommand, TCommandResult> _decorated;

    public CommandHandlerLoggingDecorator(
        ICommandHandler<TCommand, TCommandResult> decorated,
        ILogger<CommandHandlerLoggingDecorator<TCommand, TCommandResult>> logger
    )
        : base(logger)
    {
        _decorated = decorated;
    }

    public async Task<TCommandResult> Handle(
        TCommand request,
        CancellationToken cancellationToken
    ) => await HandleAndLogMessage(request, cancellationToken, _decorated.Handle);
}
