using Microsoft.EntityFrameworkCore;
using WebApiTemplate.Core;

namespace WebApiTemplate.Infrastructure.Persistence;

/// <summary>
/// Unit of work factory implementation based on Entity Framework.
/// </summary>
public class UnitOfWorkFactory(IDbContextFactory<AppDbContext> dbContextFactory)
    : IUnitOfWorkFactory
{
    /// <summary>
    /// Creates a new instance of the unit of work.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>An instance of the UnitOfWork class.</returns>
    public async Task<IUnitOfWork> Create(CancellationToken cancellationToken = default) =>
        new UnitOfWork(await dbContextFactory.CreateDbContextAsync(cancellationToken));
}
