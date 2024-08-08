using HumbleMediator;
using WebApiTemplate.Core;

namespace WebApiTemplate.Application.Customers.Commands;

/// <summary>
/// <see cref="ICommand{T}"/> implementation for deleting a customer entity.
/// </summary>
/// <param name="Id">The id of the entity to delete.</param>
public record DeleteCustomerCommand(int Id) : ICommand<Nothing>;
