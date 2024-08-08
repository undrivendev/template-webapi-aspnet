namespace WebApiTemplate.Core;

/// <summary>
/// Base interface for read repositories.
/// </summary>
/// <typeparam name="T">The domain entity type, must inherit from BaseEntity.</typeparam>
public interface IReadRepository<T>
    where T : BaseEntity
{
    /// <summary>
    /// Get the entity by its id.
    /// </summary>
    /// <param name="id">The id of the entity to get.</param>
    /// <returns>The entity, if found, otherwise null.</returns>
    public Task<T?> GetById(int id);
}
