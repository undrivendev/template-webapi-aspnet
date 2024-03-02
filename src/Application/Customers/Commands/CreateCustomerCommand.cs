using HumbleMediator;
using WebApiTemplate.Core.Customers;

namespace WebApiTemplate.Application.Customers.Commands;

public record CreateCustomerCommand(Customer Customer) : ICommand<int>;
