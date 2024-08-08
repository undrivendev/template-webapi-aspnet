namespace WebApiTemplate.Core;

/// <summary>
/// Unit of work factory interface.
/// </summary>
public interface IUnitOfWorkFactory
{
    /// <summary>
    /// Creates a new instance of the unit of work.
    /// </summary>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken" />.</param>
    /// <returns>An instance of the <see cref="IUnitOfWork"/> interface.</returns>
    Task<IUnitOfWork> Create(CancellationToken cancellationToken = default);
}
