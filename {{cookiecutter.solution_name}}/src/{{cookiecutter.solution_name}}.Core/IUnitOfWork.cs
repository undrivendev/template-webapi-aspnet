namespace {{cookiecutter.solution_name}}.Core;

public interface IUnitOfWork : IDisposable, IAsyncDisposable
{
    Task<Nothing> Commit(CancellationToken cancellationToken = default);
}
