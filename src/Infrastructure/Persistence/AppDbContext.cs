using Microsoft.EntityFrameworkCore;
using WebApiTemplate.Core.Customers;

namespace WebApiTemplate.Infrastructure.Persistence;

/// <summary>
/// The application Entity Framework database context.
/// </summary>
public class AppDbContext : DbContext
{
    /// <summary>
    /// Gets the customers database set.
    /// </summary>
    public DbSet<Customer> Customers => Set<Customer>();

    /// <summary>
    /// Initializes a new instance of the <see cref="AppDbContext"/> class.
    /// </summary>
    /// <param name="options"></param>
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
}
