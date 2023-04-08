using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using {{cookiecutter.solution_name}}.Infrastructure.Persistence;
using Xunit;

namespace {{cookiecutter.solution_name}}.IntegrationTests.{{cookiecutter.sample_entity_name}}s.Controllers;

public class GetByIdTests : BaseTestClass
{
    public GetByIdTests(AppWebApplicationFactory factory)
        : base(factory) { }

    [Fact]
    public async Task With{{cookiecutter.sample_entity_name}}PresentInDbShouldReturnCorrectly()
    {
        await _factory.ResetDatabase();
        const int id = 23;

        var contextFactory = _factory.Services.GetRequiredService<
            IDbContextFactory<AppDbContext>
        >();
        var context = await contextFactory.CreateDbContextAsync();
        context.{{cookiecutter.sample_entity_name}}s.Add(new Core.{{cookiecutter.sample_entity_name}}s.{{cookiecutter.sample_entity_name}}(id));
        await context.SaveChangesAsync();

        var client = _factory.CreateClient();
        var response = await client.GetAsync($"/api/customers/{id}");

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var customer = await response.Content.ReadFromJsonAsync<Core.{{cookiecutter.sample_entity_name}}s.{{cookiecutter.sample_entity_name}}>();
        customer.Should().NotBeNull();
        customer!.Id.Should().Be(id);
    }

    [Fact]
    public async Task WithNo{{cookiecutter.sample_entity_name}}PresentInDbShouldReturnNotFound()
    {
        await _factory.ResetDatabase();
        const int id = 483930;

        var client = _factory.CreateClient();
        var response = await client.GetAsync($"/api/customers/{id}");

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}
