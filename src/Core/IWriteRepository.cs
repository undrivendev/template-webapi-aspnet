namespace WebApiTemplate.Core;

/// <summary>
/// Base interface for write repositories.
/// </summary>
/// <typeparam name="T">The domain entity type, must inherit from BaseEntity.</typeparam>
public interface IWriteRepository<in T>
    where T : BaseEntity
{
    /// <summary>
    /// Create a new entity.
    /// </summary>
    /// <param name="entity">The new entity to create.</param>
    /// <param name="uow">The Unit of Work to include the operation in.</param>
    /// <returns>An instance of the <see cref="Nothing" /> class.</returns>
    public Task<Nothing> Create(T entity, IUnitOfWork uow);

    /// <summary>
    /// Update an existing entity.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <param name="uow">The Unit of Work to include the operation in.</param>
    /// <returns>An instance of the <see cref="Nothing" /> class.</returns>
    public Task<Nothing> Update(T entity, IUnitOfWork uow);

    /// <summary>
    /// Delete an entity by its Id.
    /// </summary>
    /// <param name="id">The id of the identity to delete.</param>
    /// <param name="uow">The Unit of Work to include the operation in.</param>
    /// <returns>An instance of the <see cref="Nothing" /> class.</returns>
    public Task<Nothing> Delete(int id, IUnitOfWork uow);
}
