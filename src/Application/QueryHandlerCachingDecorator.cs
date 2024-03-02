using System.Text.Json;
using HumbleMediator;
using Microsoft.Extensions.Caching.Distributed;

namespace WebApiTemplate.Application;

public sealed class QueryHandlerCachingDecorator<TQuery, TQueryResult>
    : IQueryHandler<TQuery, TQueryResult>
    where TQuery : IQuery<TQueryResult>
{
    private readonly IQueryHandler<TQuery, TQueryResult> _decorated;
    private readonly IDistributedCache _cache;

    public QueryHandlerCachingDecorator(
        IQueryHandler<TQuery, TQueryResult> decorated,
        IDistributedCache cache
    )
    {
        _decorated = decorated;
        _cache = cache;
    }

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
