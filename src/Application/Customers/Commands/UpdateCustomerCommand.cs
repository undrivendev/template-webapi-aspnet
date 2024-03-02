using HumbleMediator;
using WebApiTemplate.Core;
using WebApiTemplate.Core.Customers;

namespace WebApiTemplate.Application.Customers.Commands;

public record UpdateCustomerCommand(int Id, Customer Customer) : ICommand<Nothing>;
