using WebApiTemplate.Core;
using WebApiTemplate.Core.Customers;
using WebApiTemplate.Core.Mediator;

namespace WebApiTemplate.Application.Customers.Commands;

public record UpdateCustomerCommand(int Id, Customer Customer) : ICommand<Nothing>;