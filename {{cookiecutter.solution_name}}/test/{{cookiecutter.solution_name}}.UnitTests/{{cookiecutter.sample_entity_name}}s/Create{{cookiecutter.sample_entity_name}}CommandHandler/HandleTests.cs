using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using {{cookiecutter.solution_name}}.Application.{{cookiecutter.sample_entity_name}}s.Commands;
using {{cookiecutter.solution_name}}.Core;
using {{cookiecutter.solution_name}}.Core.{{cookiecutter.sample_entity_name}}s;
using Xunit;

namespace {{cookiecutter.solution_name}}.UnitTests.{{cookiecutter.sample_entity_name}}s.Create{{cookiecutter.sample_entity_name}}CommandHandler;

public class HandleTests
{
    [Fact]
    public async Task WithValidRequestShouldCallRepository()
    {
        // Arrange
        var mockWriteRepository = new Mock<I{{cookiecutter.sample_entity_name}}WriteRepository>();
        mockWriteRepository
            .Setup(e => e.Create(It.IsAny<{{cookiecutter.sample_entity_name}}>(), It.IsAny<IUnitOfWork>()))
            .ReturnsAsync(Nothing.Instance);

        var mockUow = new Mock<IUnitOfWork>();

        var mockUowFactory = new Mock<IUnitOfWorkFactory>();
        mockUowFactory
            .Setup(e => e.Create(It.IsAny<CancellationToken>()))
            .ReturnsAsync(mockUow.Object);

        var sut = new Application.{{cookiecutter.sample_entity_name}}s.Commands.Create{{cookiecutter.sample_entity_name}}CommandHandler(
            mockUowFactory.Object,
            mockWriteRepository.Object
        );
        var newEntity = new {{cookiecutter.sample_entity_name}}(13452);

        // Act
        var act = () => sut.Handle(new Create{{cookiecutter.sample_entity_name}}Command(newEntity));

        // Assert
        await act.Should().NotThrowAsync();
        mockWriteRepository.Verify(e => e.Create(newEntity, It.IsAny<IUnitOfWork>()), Times.Once);
        mockWriteRepository.VerifyNoOtherCalls();
    }
}
