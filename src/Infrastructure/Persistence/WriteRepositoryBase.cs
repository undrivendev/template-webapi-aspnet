using WebApiTemplate.Core;

namespace WebApiTemplate.Infrastructure.Persistence;

public abstract class WriteRepositoryBase<T> : IWriteRepository<T>
    where T : BaseEntity
{
    public virtual Task<Nothing> Create(T entity, IUnitOfWork uow)
    {
        ((UnitOfWork)uow).DbContext.Add(entity);
        return Task.FromResult(Nothing.Instance);
    }

    public virtual Task<Nothing> Update(T entity, IUnitOfWork uow)
    {
        ((UnitOfWork)uow).DbContext.Update(entity);
        return Task.FromResult(Nothing.Instance);
    }

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
