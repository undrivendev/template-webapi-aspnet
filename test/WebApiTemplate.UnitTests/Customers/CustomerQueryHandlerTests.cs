using FluentAssertions;
using Moq;
using WebApiTemplate.Application.Customers;
using WebApiTemplate.Application.Customers.Queries;
using WebApiTemplate.Core.Customers;
using Xunit;

namespace WebApiTemplate.UnitTests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        // Arrange
        var expected = new Customer(1);
        var mock = new Mock<ICustomerReadRepository>();
        mock.Setup(e => e.GetById(It.IsAny<int>())).ReturnsAsync(expected);

        var sut = new CustomerQueryHandler(mock.Object);
        
        // Act
        var result = sut.Handle(new GetCustomerByIdQuery(1));

        // Assert
        result.Should().BeEquivalentTo(expected);
    }
}