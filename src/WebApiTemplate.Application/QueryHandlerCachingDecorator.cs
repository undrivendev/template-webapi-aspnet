using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using WebApiTemplate.Core.Mediator;

namespace WebApiTemplate.Application;

public class QueryHandlerCachingDecorator<TQuery, TResult> : IQueryHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
    private readonly IQueryHandler<TQuery, TResult> _decorated;
    private readonly IDistributedCache _cache;

    public QueryHandlerCachingDecorator(
        IQueryHandler<TQuery, TResult> decorated,
        IDistributedCache cache)
    {
        _decorated = decorated;
        _cache = cache;
    }

    public async Task<TResult> Handle(TQuery query, CancellationToken cancellationToken = default)
    {
        var cacheKey = $"{typeof(TQuery).Name}-{JsonSerializer.Serialize(query)}";
        var cachedResult = await _cache.GetStringAsync(cacheKey, cancellationToken);
        if (!string.IsNullOrWhiteSpace(cachedResult))
        {
            return JsonSerializer.Deserialize<TResult>(cachedResult)!;
        }

        var result = await _decorated.Handle(query, cancellationToken);
        await _cache.SetStringAsync(
            cacheKey,
            JsonSerializer.Serialize(result),
            new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5), // TODO: parametrize
            },
            cancellationToken);

        return result;
    }
}