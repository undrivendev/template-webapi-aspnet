namespace WebApiTemplate.Core.Mediator;

public interface IMediator
{
    Task<TQueryResult> SendQuery<TQuery, TQueryResult>(TQuery query, CancellationToken cancellationToken = default)
        where TQuery : IQuery<TQueryResult>;

    Task<TCommandResult> SendCommand<TCommand, TCommandResult>(TCommand command,
        CancellationToken cancellationToken = default)
        where TCommand : ICommand<TCommandResult>;
}