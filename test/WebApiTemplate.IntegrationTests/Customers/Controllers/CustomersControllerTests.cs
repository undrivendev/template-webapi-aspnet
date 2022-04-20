using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using WebApiTemplate.Api.Customers;
using WebApiTemplate.Core.Customers;
using Xunit;

namespace WebApiTemplate.IntegrationTests;

[Trait("Category", "Integration")]
public class CustomersControllerTests : IClassFixture<AppWebApplicationFactory>
{
    readonly HttpClient _client;

    public CustomersControllerTests(AppWebApplicationFactory application)
    {
        _client = application.CreateClient();
    }

    
    [Fact]
    public async Task GetById_ValidRequest_ReturnsCorrectly()
    {
        var response = await _client.GetAsync("/api/customers/1");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var customer = await response.Content.ReadFromJsonAsync<Customer>();

        customer.Should().NotBeNull();
        customer!.Id.Should().Be(1);
    }
}