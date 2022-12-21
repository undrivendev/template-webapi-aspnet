using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Respawn;
using Respawn.Graph;
using WebApiTemplate.Infrastructure.Persistence;
using Xunit;

namespace WebApiTemplate.IntegrationTests;

public class AppWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly PostgreSqlTestcontainer _dbContainer;
    private Respawner _respawner;

    public AppWebApplicationFactory()
    {
        _dbContainer = new TestcontainersBuilder<PostgreSqlTestcontainer>()
            .WithDatabase(
                new PostgreSqlTestcontainerConfiguration
                {
                    Database = Constants.TestPostgresDatabase,
                    Username = Constants.TestPostgresUsername,
                    Password = Constants.TestPostgresPassword,
                    Port = Constants.TestPostgresPort,
                }
            )
            .Build();
    }

    public async Task InitializeAsync()
    {
        await _dbContainer.StartAsync();

        var contextFactory = this.Services.GetRequiredService<IDbContextFactory<AppDbContext>>();
        var context = await contextFactory.CreateDbContextAsync();
        var connection = context.Database.GetDbConnection();
        await connection.OpenAsync();
        _respawner = await Respawner.CreateAsync(
            connection,
            new RespawnerOptions
            {
                DbAdapter = DbAdapter.Postgres,
                TablesToIgnore = new Table[] { "__EFMigrationsHistory" },
            }
        );
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var typesToRemove = new[]
            {
                typeof(DbContextOptions),
                typeof(DbContextOptions<AppDbContext>),
                typeof(IDbContextFactory<AppDbContext>),
                typeof(ReadRepositoryOptions),
            };

            var toRemove = services.Where(e => typesToRemove.Contains(e.ServiceType)).ToList();
            foreach (var descriptor in toRemove)
            {
                services.Remove(descriptor);
            }

            services.AddPooledDbContextFactory<AppDbContext>(
                options =>
                    options.UseNpgsql(_dbContainer.ConnectionString).UseSnakeCaseNamingConvention()
            );

            Program.Container.Options.AllowOverridingRegistrations = true;
            Program.Container.Register(
                () =>
                    new ReadRepositoryOptions { ConnectionString = _dbContainer.ConnectionString, }
            );
            Program.Container.Register(
                () =>
                    new WriteRepositoryOptions { ConnectionString = _dbContainer.ConnectionString, }
            );
        });
    }

    public async Task ResetDatabase()
    {
        var contextFactory = this.Services.GetRequiredService<IDbContextFactory<AppDbContext>>();
        var context = await contextFactory.CreateDbContextAsync();
        var connection = context.Database.GetDbConnection();
        await connection.OpenAsync();
        await _respawner.ResetAsync(connection);
    }

    public new async Task DisposeAsync()
    {
        await _dbContainer.StopAsync();
        await _dbContainer.DisposeAsync();
    }
}
