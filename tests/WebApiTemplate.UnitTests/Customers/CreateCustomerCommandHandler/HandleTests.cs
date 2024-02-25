using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using WebApiTemplate.Application.Customers.Commands;
using WebApiTemplate.Core;
using WebApiTemplate.Core.Customers;
using Xunit;

namespace WebApiTemplate.UnitTests.Customers.CreateCustomerCommandHandler;

public class HandleTests
{
    [Fact]
    public async Task WithValidRequestShouldCallRepository()
    {
        // Arrange
        var mockWriteRepository = new Mock<ICustomerWriteRepository>();
        mockWriteRepository
            .Setup(e => e.Create(It.IsAny<Customer>(), It.IsAny<IUnitOfWork>()))
            .ReturnsAsync(Nothing.Instance);

        var mockUow = new Mock<IUnitOfWork>();

        var mockUowFactory = new Mock<IUnitOfWorkFactory>();
        mockUowFactory
            .Setup(e => e.Create(It.IsAny<CancellationToken>()))
            .ReturnsAsync(mockUow.Object);

        var sut = new Application.Customers.Commands.CreateCustomerCommandHandler(
            mockUowFactory.Object,
            mockWriteRepository.Object
        );
        var newEntity = new Customer(13452);

        // Act
        var act = () => sut.Handle(new CreateCustomerCommand(newEntity));

        // Assert
        await act.Should().NotThrowAsync();
        mockWriteRepository.Verify(e => e.Create(newEntity, It.IsAny<IUnitOfWork>()), Times.Once);
        mockWriteRepository.VerifyNoOtherCalls();
    }
}
