using System.Net;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using WebApiTemplate.Infrastructure.Persistence;
using Xunit;

namespace WebApiTemplate.IntegrationTests.Customers.Controllers;

public class GetByIdTests : BaseTestClass
{
    public GetByIdTests(AppWebApplicationFactory factory)
        : base(factory) { }

    [Fact]
    public async Task WithCustomerPresentInDbShouldReturnCorrectly()
    {
        await _factory.ResetDatabase();
        const int id = 23;

        var contextFactory = _factory.Services.GetRequiredService<
            IDbContextFactory<AppDbContext>
        >();
        var context = await contextFactory.CreateDbContextAsync();
        context.Customers.Add(new Core.Customers.Customer(id));
        await context.SaveChangesAsync();

        var client = _factory.CreateClient();
        var response = await client.GetAsync($"/api/customers/{id}");

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

        var client = _factory.CreateClient();
        var response = await client.GetAsync($"/api/customers/{id}");

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}
