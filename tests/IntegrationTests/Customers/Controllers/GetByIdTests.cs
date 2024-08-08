using System.Net;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using WebApiTemplate.Infrastructure.Persistence;
using Xunit;

namespace WebApiTemplate.IntegrationTests.Customers.Controllers;

public class GetByIdTests(AppWebApplicationFactory factory) : BaseTestClass(factory)
{
    [Fact]
    public async Task WithCustomerPresentInDbShouldReturnCorrectly()
    {
        await _factory.ResetDatabase();
        const int id = 23;

        var contextFactory = _factory.Services.GetRequiredService<
            IDbContextFactory<AppDbContext>
        >();
        await using var context = await contextFactory.CreateDbContextAsync();
        context.Customers.Add(new Core.Customers.Customer(id));
        await context.SaveChangesAsync();

        using var client = _factory.CreateClient();
        using var response = await client.GetAsync($"/api/customers/{id}");

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var customer = await response.Content.ReadFromJsonAsync<Core.Customers.Customer>();
        customer.Should().NotBeNull();
        customer!.Id.Should().Be(id);
    }

    [Fact]
    public async Task WithNoCustomerPresentInDbShouldReturnNotFound()
    {
        await _factory.ResetDatabase();
        const int id = 483930;

        using var client = _factory.CreateClient();
        using var response = await client.GetAsync($"/api/customers/{id}");

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}
