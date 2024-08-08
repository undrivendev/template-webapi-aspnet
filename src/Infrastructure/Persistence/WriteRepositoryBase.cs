using WebApiTemplate.Core;

namespace WebApiTemplate.Infrastructure.Persistence;

/// <summary>
/// Base class for write repositories.
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class WriteRepositoryBase<T> : IWriteRepository<T>
    where T : BaseEntity
{
    /// <summary>
    /// Creates a new entity.
    /// </summary>
    /// <param name="entity">The entity to create.</param>
    /// <param name="uow">The unit of work to use.</param>
    /// <returns>An instance of <see cref="Nothing"/>.</returns>
    public virtual Task<Nothing> Create(T entity, IUnitOfWork uow)
    {
        ((UnitOfWork)uow).DbContext.Add(entity);
        return Task.FromResult(Nothing.Instance);
    }

    /// <summary>
    /// Updates an entity.
    /// </summary>
    /// <param name="entity">The entity containing the updated values.</param>
    /// <param name="uow">The unit of work to use.</param>
    /// <returns>An instance of <see cref="Nothing"/>.</returns>
    public virtual Task<Nothing> Update(T entity, IUnitOfWork uow)
    {
        ((UnitOfWork)uow).DbContext.Update(entity);
        return Task.FromResult(Nothing.Instance);
    }

    /// <summary>
    /// Deletes an entity by its id.
    /// </summary>
    /// <param name="id">The id of the entity to delete.</param>
    /// <param name="uow">The unit of work to use.</param>
    /// <returns>An instance of <see cref="Nothing"/>.</returns>
    public virtual async Task<Nothing> Delete(int id, IUnitOfWork uow)
    {
        var dbContext = ((UnitOfWork)uow).DbContext;
        var entityToDelete = await dbContext.FindAsync(typeof(T), id);
        if (entityToDelete is not null)
        {
            dbContext.Remove(entityToDelete);
        }

        return Nothing.Instance;
    }
}
