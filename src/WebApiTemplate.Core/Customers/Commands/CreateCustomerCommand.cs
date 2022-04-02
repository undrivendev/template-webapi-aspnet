using WebApiTemplate.Core.Mediator;

namespace WebApiTemplate.Core.Customers.Commands;

public record CreateCustomerCommand(Customer Customer) : ICommand<Guid>;