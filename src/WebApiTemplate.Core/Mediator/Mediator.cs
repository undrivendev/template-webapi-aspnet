using WebApiTemplate.Core.Mediator.DependencyInjection;

namespace WebApiTemplate.Core.Mediator;

public class Mediator : IMediator
{
    private readonly IContainer _container;

    public Mediator(IContainer container)
    {
        _container = container;
    }

    public Task<TQueryResult> SendQuery<TQuery, TQueryResult>(
        TQuery query,
        CancellationToken cancellationToken = default)
        where TQuery : IQuery<TQueryResult>
    {
        var service = _container.Resolve<IQueryHandler<TQuery, TQueryResult>>();
        return service.Handle(query, cancellationToken);
    }

    public Task<TCommandResult> SendCommand<TCommand, TCommandResult>(
        TCommand command,
        CancellationToken cancellationToken = default)
        where TCommand : ICommand<TCommandResult>
    {
        var service = _container.Resolve<ICommandHandler<TCommand, TCommandResult>>();
        return service.Handle(command, cancellationToken);
    }
}