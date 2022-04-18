using WebApiTemplate.Core;
using WebApiTemplate.Core.Mediator;

namespace WebApiTemplate.Application.Customers.Commands;

public record DeleteCustomerCommand(int Id) : ICommand<Nothing>;