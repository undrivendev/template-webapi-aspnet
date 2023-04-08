using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using {{cookiecutter.solution_name}}.Api.{{cookiecutter.sample_entity_name}}s.Requests;
using {{cookiecutter.solution_name}}.Infrastructure.Persistence;
using Xunit;

namespace {{cookiecutter.solution_name}}.IntegrationTests.{{cookiecutter.sample_entity_name}}s.Controllers;

public class CreateTests : BaseTestClass
{
    public CreateTests(AppWebApplicationFactory factory)
        : base(factory) { }

    [Fact]
    public async Task WithValidRequestShouldCreateCorrectly()
    {
        await _factory.ResetDatabase();

        var client = _factory.CreateClient();
        var request = new Create{{cookiecutter.sample_entity_name}}Request();
        var response = await client.PostAsJsonAsync($"/api/customers", request);

        response.StatusCode.Should().Be(HttpStatusCode.Created);

        var contextFactory = _factory.Services.GetRequiredService<
            IDbContextFactory<AppDbContext>
        >();
        var context = await contextFactory.CreateDbContextAsync();

        var result = await context.{{cookiecutter.sample_entity_name}}s.SingleOrDefaultAsync();
        result.Should().NotBeNull();
    }
}
