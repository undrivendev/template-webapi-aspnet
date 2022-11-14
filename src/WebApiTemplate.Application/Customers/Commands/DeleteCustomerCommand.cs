using HumbleMediator;
using WebApiTemplate.Core;

namespace WebApiTemplate.Application.Customers.Commands;

public record DeleteCustomerCommand(int Id) : ICommand<Nothing>;
