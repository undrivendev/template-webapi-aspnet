using System.Data.Common;
using Dapper.Contrib.Extensions;
using WebApiTemplate.Core;

namespace WebApiTemplate.Infrastructure.Persistence;

/// <summary>
/// Base class for read repositories.
/// </summary>
/// <param name="db">The database data source.</param>
/// <typeparam name="T">The entity type.</typeparam>
public abstract class ReadRepositoryBase<T>(DbDataSource db) : IReadRepository<T>
    where T : BaseEntity
{
    /// <summary>
    /// Gets the entity by its id.
    /// </summary>
    /// <param name="id">The id of the entity to get.</param>
    /// <returns>The entity with the specified id.</returns>
    public virtual async Task<T?> GetById(int id)
    {
        await using var conn = await db.OpenConnectionAsync();
        return await conn.GetAsync<T>(id);
    }
}
