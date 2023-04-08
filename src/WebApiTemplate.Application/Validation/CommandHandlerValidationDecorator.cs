using FluentValidation;
using HumbleMediator;

namespace WebApiTemplate.Application.Validation;

public sealed class CommandHandlerValidationDecorator<TCommand, TCommandResult>
    : BaseValidationDecorator<TCommand>,
        ICommandHandler<TCommand, TCommandResult>
    where TCommand : ICommand<TCommandResult>
{
    private readonly ICommandHandler<TCommand, TCommandResult> _decorated;

    public CommandHandlerValidationDecorator(
        ICommandHandler<TCommand, TCommandResult> decorated,
        IEnumerable<IValidator<TCommand>> validators
    )
        : base(validators)
    {
        _decorated = decorated;
    }

    public async Task<TCommandResult> Handle(TCommand request, CancellationToken cancellationToken)
    {
        await Validate(request, cancellationToken);
        return await _decorated.Handle(request, cancellationToken);
    }
}
