namespace WebApiTemplate.Core;

public interface IWriteRepository<in T> where T : BaseEntity
{
    public Task<Nothing> Create(T entity, IUnitOfWork uow);
    public Task<Nothing> Update(T entity, IUnitOfWork uow);
    public Task<Nothing> Delete(Guid id, IUnitOfWork uow);
}