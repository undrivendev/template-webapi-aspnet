using System.Net;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using WebApiTemplate.Infrastructure.Persistence;
using Xunit;

namespace WebApiTemplate.IntegrationTests.Customers.Controllers;

public class DeleteTests : BaseTestClass
{
    public DeleteTests(AppWebApplicationFactory factory)
        : base(factory) { }

    [Fact]
    public async Task WithCustomerPresentDeletesCorrectly()
    {
        await _factory.ResetDatabase();
        const int id = 1278;

        var contextFactory = _factory.Services.GetRequiredService<
            IDbContextFactory<AppDbContext>
        >();
        var context = await contextFactory.CreateDbContextAsync();
        context.Customers.Add(new Core.Customers.Customer(id));
        await context.SaveChangesAsync();

        var client = _factory.CreateClient();
        var response = await client.DeleteAsync($"/api/customers/{id}");

        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        var allCustomers = await context.Customers.ToListAsync();
        allCustomers.Should().BeEmpty();
    }
}
