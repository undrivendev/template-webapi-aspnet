using Xunit;

namespace {{cookiecutter.solution_name}}.IntegrationTests;

[CollectionDefinition(nameof(AppTestCollection))]
public class AppTestCollection : ICollectionFixture<AppWebApplicationFactory> { }
