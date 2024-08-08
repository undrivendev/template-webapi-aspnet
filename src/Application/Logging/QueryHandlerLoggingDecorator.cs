using HumbleMediator;
using Microsoft.Extensions.Logging;

namespace WebApiTemplate.Application.Logging;

/// <summary>
/// Decorator for logging command handlers.
/// </summary>
/// <typeparam name="TQuery"></typeparam>
/// <typeparam name="TQueryResult"></typeparam>
public sealed class QueryHandlerLoggingDecorator<TQuery, TQueryResult>
    : BaseLoggingDecorator<TQuery>,
        IQueryHandler<TQuery, TQueryResult>
    where TQuery : IQuery<TQueryResult>
{
    private readonly IQueryHandler<TQuery, TQueryResult> _decorated;

    /// <summary>
    /// Initializes a new instance of the <see cref="QueryHandlerLoggingDecorator{TQuery, TQueryResult}"/> class.
    /// </summary>
    /// <param name="decorated">The query handler to decorate.</param>
    /// <param name="logger">The logger to use.</param>
    public QueryHandlerLoggingDecorator(
        IQueryHandler<TQuery, TQueryResult> decorated,
        ILogger<QueryHandlerLoggingDecorator<TQuery, TQueryResult>> logger
    )
        : base(logger)
    {
        _decorated = decorated;
    }

    /// <summary>
    /// Handles the query and logs the message.
    /// </summary>
    /// <param name="request">The query to handle.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>The result of the decorated handler.</returns>
    public async Task<TQueryResult> Handle(TQuery request, CancellationToken cancellationToken) =>
        await HandleAndLogMessage(request, cancellationToken, _decorated.Handle);
}
