using Xunit;

namespace WebApiTemplate.IntegrationTests;

[Trait("Category", "Integration")]
[Collection(nameof(AppTestCollection))]
public abstract class BaseTestClass(AppWebApplicationFactory factory)
{
    protected readonly AppWebApplicationFactory _factory = factory;
}
