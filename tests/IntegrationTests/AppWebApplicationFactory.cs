// ReSharper disable ClassNeverInstantiated.Global

#pragma warning disable CS8618

using System.Data.Common;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Respawn;
using Respawn.Graph;
using Testcontainers.PostgreSql;
using WebApiTemplate.Infrastructure.Persistence;
using Xunit;

namespace WebApiTemplate.IntegrationTests;

public class AppWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly PostgreSqlContainer _dbContainer;
    private Respawner _respawner;

    public AppWebApplicationFactory()
    {
        _dbContainer = new PostgreSqlBuilder()
            .WithDatabase(Constants.TestPostgresDatabase)
            .WithUsername(Constants.TestPostgresUsername)
            .WithPassword(Constants.TestPostgresPassword)
            .WithExposedPort(Constants.TestPostgresPort)
            .WithPortBinding(Constants.TestPostgresPort)
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
                typeof(NpgsqlDataSource),
                typeof(DbConnection),
                typeof(DbDataSource),
                typeof(NpgsqlConnection),
            };

            var toRemove = services.Where(e => typesToRemove.Contains(e.ServiceType)).ToList();
            foreach (var descriptor in toRemove)
            {
                services.Remove(descriptor);
            }

            services.AddNpgsqlDataSource(_dbContainer.GetConnectionString());
            services.AddPooledDbContextFactory<AppDbContext>(
                (sp, options) =>
                    options
                        .UseNpgsql(sp.GetRequiredService<NpgsqlDataSource>())
                        .UseSnakeCaseNamingConvention()
            );

            Program.Container.Options.AllowOverridingRegistrations = true;
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
