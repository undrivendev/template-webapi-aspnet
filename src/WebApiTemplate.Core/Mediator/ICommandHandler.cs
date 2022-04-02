namespace WebApiTemplate.Core.Mediator;

public interface ICommandHandler<in TCommand, TCommandResult> where TCommand : ICommand<TCommandResult>
{
    Task<TCommandResult> Handle(TCommand query, CancellationToken cancellationToken = default);
}