using System.Diagnostics.CodeAnalysis;
using WebApiTemplate.Core;

namespace WebApiTemplate.Infrastructure.Persistence;

/// <summary>
/// The unit of work implementation based on Entity Framework.
/// </summary>
[SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP007:Don\'t dispose injected")]
public sealed class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
{
    internal AppDbContext DbContext { get; } = dbContext;

    /// <summary>
    /// Commit the changes made in the unit of work.
    /// </summary>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken" />.</param>
    /// <returns>An instance of the <see cref="Nothing" /> class.</returns>
    public async Task<Nothing> Commit(CancellationToken cancellationToken = default)
    {
        await DbContext.SaveChangesAsync(cancellationToken);
        return Nothing.Instance;
    }

    /// <inheritdoc />
    public void Dispose() => DbContext.Dispose();

    /// <inheritdoc />
    public ValueTask DisposeAsync() => DbContext.DisposeAsync();
}
