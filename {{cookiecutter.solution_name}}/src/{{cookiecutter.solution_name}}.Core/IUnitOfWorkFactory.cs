namespace {{cookiecutter.solution_name}}.Core;

public interface IUnitOfWorkFactory
{
    Task<IUnitOfWork> Create(CancellationToken cancellationToken = default);
}
