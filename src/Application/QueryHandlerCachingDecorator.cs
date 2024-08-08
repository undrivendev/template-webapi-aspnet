using System.Text.Json;
using HumbleMediator;
using Microsoft.Extensions.Caching.Distributed;

namespace WebApiTemplate.Application;

/// <summary>
/// Decorator for caching query results.
/// </summary>
/// <typeparam name="TQuery">The type of the query to handle.</typeparam>
/// <typeparam name="TQueryResult">The type of the query result.</typeparam>
public sealed class QueryHandlerCachingDecorator<TQuery, TQueryResult>
    : IQueryHandler<TQuery, TQueryResult>
    where TQuery : IQuery<TQueryResult>
{
    private readonly IQueryHandler<TQuery, TQueryResult> _decorated;
    private readonly IDistributedCache _cache;

    /// <summary>
    /// Initializes a new instance of the <see cref="QueryHandlerCachingDecorator{TQuery, TQueryResult}"/> class.
    /// </summary>
    /// <param name="decorated">The query handler to decorate.</param>
    /// <param name="cache">The cache to use.</param>
    public QueryHandlerCachingDecorator(
        IQueryHandler<TQuery, TQueryResult> decorated,
        IDistributedCache cache
    )
    {
        _decorated = decorated;
        _cache = cache;
    }

    /// <summary>
    /// Handles the query and caches the result.
    /// </summary>
    /// <param name="request">The query to handle.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns></returns>
    public async Task<TQueryResult> Handle(TQuery request, CancellationToken cancellationToken)
    {
        var cacheKey = $"{typeof(TQuery).Name}-{JsonSerializer.Serialize(request)}";
        var cachedResult = await _cache.GetStringAsync(cacheKey, cancellationToken);
        if (!string.IsNullOrWhiteSpace(cachedResult))
        {
            return JsonSerializer.Deserialize<TQueryResult>(cachedResult)!;
        }

        var result = await _decorated.Handle(request, cancellationToken);
        await _cache.SetStringAsync(
            cacheKey,
            JsonSerializer.Serialize(result),
            new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5), // TODO: parametrize
            },
            cancellationToken
        );

        return result;
    }
}
