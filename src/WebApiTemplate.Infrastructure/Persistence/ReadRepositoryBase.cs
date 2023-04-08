using System.Data.Common;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Options;
using Npgsql;
using WebApiTemplate.Core;

namespace WebApiTemplate.Infrastructure.Persistence;

public abstract class ReadRepositoryBase<T> : IReadRepository<T>
    where T : BaseEntity
{
    protected readonly DbDataSource _db;

    public ReadRepositoryBase(DbDataSource db)
    {
        _db = db;
    }

    public virtual async Task<T?> GetById(int id)
    {
        await using var conn = await _db.OpenConnectionAsync();
        return await conn.GetAsync<T>(id);
    }
}
