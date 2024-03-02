using WebApiTemplate.Core;

namespace WebApiTemplate.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    internal AppDbContext DbContext { get; }

    public UnitOfWork(AppDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<Nothing> Commit(CancellationToken cancellationToken = default)
    {
        await DbContext.SaveChangesAsync(cancellationToken);
        return Nothing.Instance;
    }

    public void Dispose()
    {
        DbContext.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return DbContext.DisposeAsync();
    }
}
