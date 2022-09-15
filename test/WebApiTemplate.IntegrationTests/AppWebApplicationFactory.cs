using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApiTemplate.Infrastructure.Persistence;

namespace WebApiTemplate.IntegrationTests;

public class AppWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var typesToRemove = new[]
            {
                typeof(DbContextOptions<AppDbContext>),
                typeof(IDbContextFactory<AppDbContext>),
            };

            var toRemove = services.Where(e => typesToRemove.Contains(e.ServiceType)).ToList();
            foreach (var descriptor in toRemove)
            {
                services.Remove(descriptor);
            }

            services.AddPooledDbContextFactory<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDbForTesting");
            });

            var sp = services.BuildServiceProvider();
            var db = sp.GetRequiredService<IDbContextFactory<AppDbContext>>().CreateDbContext();
            db.Database.EnsureCreated();

            Utils.SeedTestData(db);

            Program.Container.Options.AllowOverridingRegistrations = true;
            // TODO: swap SimpleInjector services with the test ones
        });
    }
}