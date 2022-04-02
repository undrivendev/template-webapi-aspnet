using WebApiTemplate.Core.Mediator;

namespace WebApiTemplate.Core.Customers.Commands;

public record UpdateCustomerCommand(Guid Id, Customer Customer) : ICommand<Nothing>;