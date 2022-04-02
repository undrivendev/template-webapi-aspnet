using WebApiTemplate.Core.Mediator;

namespace WebApiTemplate.Core.Customers.Commands;

public record DeleteCustomerCommand(Guid Id) : ICommand<Nothing>;