using WebApiTemplate.Core;

namespace WebApiTemplate.Infrastructure.Persistence;

public abstract class WriteRepositoryBase<T> : IWriteRepository<T>
{
    protected readonly AppDbContext _context;

    public WriteRepositoryBase(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Create(T entity)
    {
        throw new NotImplementedException();
    }

    public async Task Update(T entity)
    {
        throw new NotImplementedException();
    }

    public async Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}