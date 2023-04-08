using Microsoft.EntityFrameworkCore;
using WebApiTemplate.Core.Customers;

namespace WebApiTemplate.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<Customer> Customers => Set<Customer>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
}
