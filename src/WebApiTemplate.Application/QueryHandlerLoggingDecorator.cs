using Microsoft.Extensions.Logging;
using WebApiTemplate.Core.Mediator;

namespace WebApiTemplate.Application;

public class QueryHandlerLoggingDecorator<TQuery, TResult> : IQueryHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
    private readonly IQueryHandler<TQuery, TResult> _decorated;
    private readonly ILogger<QueryHandlerLoggingDecorator<TQuery, TResult>> _logger;

    public QueryHandlerLoggingDecorator(
        IQueryHandler<TQuery, TResult> decorated,
        ILogger<QueryHandlerLoggingDecorator<TQuery, TResult>> logger)
    {
        _decorated = decorated;
        _logger = logger;
    }

    public async Task<TResult> Handle(TQuery query, CancellationToken cancellationToken = default)
    {
        var queryName = typeof(TQuery).Name;
        try
        {
            _logger.LogInformation("Start handling query {Query}", queryName);
            var result = await _decorated.Handle(query, cancellationToken);
            _logger.LogInformation("Finish handling query {Query}", queryName);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error handling query {Query}", queryName);
            throw;
        }
    }
}