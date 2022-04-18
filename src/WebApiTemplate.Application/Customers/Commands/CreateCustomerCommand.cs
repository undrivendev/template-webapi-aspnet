using WebApiTemplate.Core.Customers;
using WebApiTemplate.Core.Mediator;

namespace WebApiTemplate.Application.Customers.Commands;

public record CreateCustomerCommand(Customer Customer) : ICommand<int>;