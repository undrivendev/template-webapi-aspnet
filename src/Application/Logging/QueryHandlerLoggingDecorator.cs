using HumbleMediator;
using Microsoft.Extensions.Logging;

namespace WebApiTemplate.Application.Logging;

public sealed class QueryHandlerLoggingDecorator<TQuery, TQueryResult>
    : BaseLoggingDecorator<TQuery>,
        IQueryHandler<TQuery, TQueryResult>
    where TQuery : IQuery<TQueryResult>
{
    private readonly IQueryHandler<TQuery, TQueryResult> _decorated;

    public QueryHandlerLoggingDecorator(
        IQueryHandler<TQuery, TQueryResult> decorated,
        ILogger<QueryHandlerLoggingDecorator<TQuery, TQueryResult>> logger
    )
        : base(logger)
    {
        _decorated = decorated;
    }

    public async Task<TQueryResult> Handle(TQuery request, CancellationToken cancellationToken) =>
        await HandleAndLogMessage(request, cancellationToken, _decorated.Handle);
}
