using System.Data.Common;
using Dapper;
using Microsoft.Extensions.Options;
using Npgsql;
using WebApiTemplate.Core;

namespace WebApiTemplate.Infrastructure.Persistence;

public abstract class ReadRepositoryBase<T> : IReadRepository<T>
{
    protected readonly IOptionsMonitor<ReadRepositoryOptions> _options;

    public ReadRepositoryBase(IOptionsMonitor<ReadRepositoryOptions> options)
    {
        _options = options;
    }

    public async Task<T> GetById(Guid id)
    {
        const string sql = $"SELECT * FROM {nameof(T)} WHERE Id = @id";
        await using DbConnection conn = new NpgsqlConnection(_options.CurrentValue.ConnectionString);
        return await conn.QueryFirstAsync<T>(sql, new { id });
    }
}