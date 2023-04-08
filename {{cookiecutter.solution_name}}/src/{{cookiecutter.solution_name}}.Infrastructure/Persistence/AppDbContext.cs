using Microsoft.EntityFrameworkCore;
using {{cookiecutter.solution_name}}.Core.{{cookiecutter.sample_entity_name}}s;

namespace {{cookiecutter.solution_name}}.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<{{cookiecutter.sample_entity_name}}> {{cookiecutter.sample_entity_name}}s => Set<{{cookiecutter.sample_entity_name}}>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
}
