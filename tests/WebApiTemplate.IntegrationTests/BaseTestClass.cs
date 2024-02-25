using Xunit;

namespace WebApiTemplate.IntegrationTests;

[Trait("Category", "Integration")]
[Collection(nameof(AppTestCollection))]
public abstract class BaseTestClass
{
    protected readonly AppWebApplicationFactory _factory;

    protected BaseTestClass(AppWebApplicationFactory factory)
    {
        _factory = factory;
    }
}
