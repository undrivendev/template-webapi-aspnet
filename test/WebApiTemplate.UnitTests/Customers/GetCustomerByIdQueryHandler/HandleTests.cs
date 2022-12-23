using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using WebApiTemplate.Application.Customers.Queries;
using WebApiTemplate.Core.Customers;
using Xunit;

namespace WebApiTemplate.UnitTests.Customers.GetCustomerByIdQueryHandler;

public class HandleTests
{
    [Fact]
    public async Task WithValidRequestShouldCallRepository()
    {
        // Arrange
        var expected = new Customer(1);
        var mock = new Mock<ICustomerReadRepository>();
        mock.Setup(e => e.GetById(It.IsAny<int>())).ReturnsAsync(expected);

        var sut = new Application.Customers.Queries.GetCustomerByIdQueryHandler(mock.Object);

        // Act
        var result = await sut.Handle(new GetCustomerByIdQuery(1));

        // Assert
        result.Should().BeEquivalentTo(expected);
    }
}
