namespace WebApiTemplate.Core;

public interface IReadRepository<T>
{
    public Task<T> GetById(Guid id);
}