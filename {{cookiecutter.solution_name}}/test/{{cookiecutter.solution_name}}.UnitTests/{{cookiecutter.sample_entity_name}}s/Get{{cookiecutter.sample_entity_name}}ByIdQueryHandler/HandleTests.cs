using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using {{cookiecutter.solution_name}}.Application.{{cookiecutter.sample_entity_name}}s.Queries;
using {{cookiecutter.solution_name}}.Core.{{cookiecutter.sample_entity_name}}s;
using Xunit;

namespace {{cookiecutter.solution_name}}.UnitTests.{{cookiecutter.sample_entity_name}}s.Get{{cookiecutter.sample_entity_name}}ByIdQueryHandler;

public class HandleTests
{
    [Fact]
    public async Task WithValidRequestShouldCallRepository()
    {
        // Arrange
        var expected = new {{cookiecutter.sample_entity_name}}(1);
        var mock = new Mock<I{{cookiecutter.sample_entity_name}}ReadRepository>();
        mock.Setup(e => e.GetById(It.IsAny<int>())).ReturnsAsync(expected);

        var sut = new Application.{{cookiecutter.sample_entity_name}}s.Queries.Get{{cookiecutter.sample_entity_name}}ByIdQueryHandler(mock.Object);

        // Act
        var result = await sut.Handle(new Get{{cookiecutter.sample_entity_name}}ByIdQuery(1));

        // Assert
        result.Should().BeEquivalentTo(expected);
    }
}
