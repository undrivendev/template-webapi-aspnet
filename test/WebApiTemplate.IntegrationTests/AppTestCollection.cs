using Xunit;

namespace WebApiTemplate.IntegrationTests;

[CollectionDefinition(nameof(AppTestCollection))]
public class AppTestCollection : ICollectionFixture<AppWebApplicationFactory> { }
