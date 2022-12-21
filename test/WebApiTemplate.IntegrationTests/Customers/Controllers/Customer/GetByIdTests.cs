using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApiTemplate.Infrastructure.Persistence;
using Xunit;

namespace WebApiTemplate.IntegrationTests.Customer;

public class GetByIdTests : BaseTestClass
{
    public GetByIdTests(AppWebApplicationFactory factory) : base(factory) { }

    [Fact]
    public async Task WithValidRequestReturnsCorrectly()
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
}
