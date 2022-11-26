using System.Text.Json;
using HumbleMediator;
using Microsoft.Extensions.Caching.Distributed;

namespace WebApiTemplate.Application;

public sealed class MediatorCachingDecorator : IMediator
{
    private readonly IMediator _decorated;
    private readonly IDistributedCache _cache;

    public MediatorCachingDecorator(IMediator decorated, IDistributedCache cache)
    {
        _decorated = decorated;
        _cache = cache;
    }

    public async Task<TQueryResult> SendQuery<TQuery, TQueryResult>(
        TQuery query,
        CancellationToken cancellationToken
    ) where TQuery : IQuery<TQueryResult>
    {
        var cacheKey = $"{typeof(TQuery).Name}-{JsonSerializer.Serialize(query)}";
        var cachedResult = await _cache.GetStringAsync(cacheKey, cancellationToken);
        if (!string.IsNullOrWhiteSpace(cachedResult))
        {
            return JsonSerializer.Deserialize<TQueryResult>(cachedResult)!;
        }

        var result = await _decorated.SendQuery<TQuery, TQueryResult>(query, cancellationToken);
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

    /// <summary>
    /// Commands are not cached.
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TCommand"></typeparam>
    /// <typeparam name="TCommandResult"></typeparam>
    /// <returns></returns>
    public async Task<TCommandResult> SendCommand<TCommand, TCommandResult>(
        TCommand command,
        CancellationToken cancellationToken
    ) where TCommand : ICommand<TCommandResult> =>
        await _decorated.SendCommand<TCommand, TCommandResult>(command, cancellationToken);
}
