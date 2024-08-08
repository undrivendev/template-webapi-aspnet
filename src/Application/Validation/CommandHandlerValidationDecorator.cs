using FluentValidation;
using HumbleMediator;

namespace WebApiTemplate.Application.Validation;

/// <summary>
/// Decorator for validating command handlers.
/// </summary>
/// <typeparam name="TCommand">The type of the command to handle.</typeparam>
/// <typeparam name="TCommandResult">The type of the command result.</typeparam>
public sealed class CommandHandlerValidationDecorator<TCommand, TCommandResult>
    : BaseValidationDecorator<TCommand>,
        ICommandHandler<TCommand, TCommandResult>
    where TCommand : ICommand<TCommandResult>
{
    private readonly ICommandHandler<TCommand, TCommandResult> _decorated;

    /// <summary>
    /// Initializes a new instance of the <see cref="CommandHandlerValidationDecorator{TCommand, TCommandResult}"/> class.
    /// </summary>
    /// <param name="decorated">The command handler to decorate.</param>
    /// <param name="validators">The validators to use.</param>
    public CommandHandlerValidationDecorator(
        ICommandHandler<TCommand, TCommandResult> decorated,
        IEnumerable<IValidator<TCommand>> validators
    )
        : base(validators)
    {
        _decorated = decorated;
    }

    /// <summary>
    /// Validates the command and handles it.
    /// </summary>
    /// <param name="request">The command to handle.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns></returns>
    public async Task<TCommandResult> Handle(TCommand request, CancellationToken cancellationToken)
    {
        await Validate(request, cancellationToken);
        return await _decorated.Handle(request, cancellationToken);
    }
}
