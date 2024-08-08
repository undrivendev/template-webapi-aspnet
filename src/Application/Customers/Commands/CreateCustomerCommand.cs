using HumbleMediator;
using WebApiTemplate.Core.Customers;

namespace WebApiTemplate.Application.Customers.Commands;

/// <summary>
/// <see cref="ICommand{T}"/> implementation for creating a new customer entity.
/// </summary>
/// <param name="Customer">The <see cref="Customer"/> instance to create.</param>
public record CreateCustomerCommand(Customer Customer) : ICommand<int>;
