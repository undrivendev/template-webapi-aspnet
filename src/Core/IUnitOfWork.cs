namespace WebApiTemplate.Core;

/// <summary>
/// The Unit of Work pattern interface.
/// </summary>
public interface IUnitOfWork : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Commit the changes made in the unit of work.
    /// </summary>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken" />.</param>
    /// <returns>An instance of the <see cref="Nothing" /> class.</returns>
    Task<Nothing> Commit(CancellationToken cancellationToken = default);
}
