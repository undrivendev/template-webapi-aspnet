using System.Data.Common;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Options;
using Npgsql;
using WebApiTemplate.Core;

namespace WebApiTemplate.Infrastructure.Persistence;

public abstract class ReadRepositoryBase<T> : IReadRepository<T> where T : BaseEntity
{
    protected readonly ReadRepositoryOptions _options;

    public ReadRepositoryBase(ReadRepositoryOptions options)
    {
        _options = options;
    }

    public virtual async Task<T> GetById(int id)
    {
        await using DbConnection conn = new NpgsqlConnection(_options.ConnectionString);
        return await conn.GetAsync<T>(id);
    }
}
