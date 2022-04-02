namespace WebApiTemplate.Core;

public interface IWriteRepository<T>
{
    public Task<Guid> Create(T entity);
    public Task Update(T entity);
    public Task Delete(Guid id);
}