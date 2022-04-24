using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApiTemplate.Api.Customers;
using WebApiTemplate.Core.Customers;
using WebApiTemplate.Infrastructure.Persistence;
using Xunit;

namespace WebApiTemplate.IntegrationTests;

[Trait("Category", "Integration")]
public class CustomersControllerTests : IClassFixture<AppWebApplicationFactory>
{
    private readonly AppWebApplicationFactory _factory;

    public CustomersControllerTests(AppWebApplicationFactory factory)
    {
        _factory = factory;
    }


    [Fact]
    public async Task GetById_ValidRequest_ReturnsCorrectly()
    {
        var client = _factory.CreateClient();
        
        var response = await client.GetAsync("/api/customers/1");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var customer = await response.Content.ReadFromJsonAsync<Customer>();

        customer.Should().NotBeNull();
        customer!.Id.Should().Be(1);
    }
}