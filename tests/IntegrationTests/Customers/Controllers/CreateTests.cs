using System.Net;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using WebApiTemplate.Api.Customers.Requests;
using WebApiTemplate.Infrastructure.Persistence;
using Xunit;

namespace WebApiTemplate.IntegrationTests.Customers.Controllers;

public class CreateTests(AppWebApplicationFactory factory) : BaseTestClass(factory)
{
    [Fact]
    public async Task WithValidRequestShouldCreateCorrectly()
    {
        await _factory.ResetDatabase();

        using var client = _factory.CreateClient();
        var request = new CreateCustomerRequest();
        using var response = await client.PostAsJsonAsync($"/api/customers", request);

        response.StatusCode.Should().Be(HttpStatusCode.Created);

        var contextFactory = _factory.Services.GetRequiredService<
            IDbContextFactory<AppDbContext>
        >();
        await using var context = await contextFactory.CreateDbContextAsync();

        var result = await context.Customers.SingleOrDefaultAsync();
        result.Should().NotBeNull();
    }
}
