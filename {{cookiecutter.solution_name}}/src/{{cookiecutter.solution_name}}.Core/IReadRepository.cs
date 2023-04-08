namespace {{cookiecutter.solution_name}}.Core;

public interface IReadRepository<T>
    where T : BaseEntity
{
    public Task<T?> GetById(int id);
}
