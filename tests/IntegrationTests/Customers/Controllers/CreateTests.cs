using System.Net;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using WebApiTemplate.Api.Customers.Requests;
using WebApiTemplate.Infrastructure.Persistence;
using Xunit;

namespace WebApiTemplate.IntegrationTests.Customers.Controllers;

public class CreateTests : BaseTestClass
{
    public CreateTests(AppWebApplicationFactory factory)
        : base(factory) { }

    [Fact]
    public async Task WithValidRequestShouldCreateCorrectly()
    {
        await _factory.ResetDatabase();

        var client = _factory.CreateClient();
        var request = new CreateCustomerRequest();
        var response = await client.PostAsJsonAsync($"/api/customers", request);

        response.StatusCode.Should().Be(HttpStatusCode.Created);

        var contextFactory = _factory.Services.GetRequiredService<
            IDbContextFactory<AppDbContext>
        >();
        var context = await contextFactory.CreateDbContextAsync();

        var result = await context.Customers.SingleOrDefaultAsync();
        result.Should().NotBeNull();
    }
}
