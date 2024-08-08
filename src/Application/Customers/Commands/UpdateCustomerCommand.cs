using HumbleMediator;
using WebApiTemplate.Core;
using WebApiTemplate.Core.Customers;

namespace WebApiTemplate.Application.Customers.Commands;

/// <summary>
/// <see cref="ICommand{T}"/> implementation for updating a customer entity.
/// </summary>
/// <param name="Id">The id of the entity to update.</param>
/// <param name="Customer">The updated entity.</param>
public record UpdateCustomerCommand(int Id, Customer Customer) : ICommand<Nothing>;
