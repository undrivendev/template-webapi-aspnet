using HumbleMediator;
using WebApiTemplate.Core;
using WebApiTemplate.Core.Customers;

namespace WebApiTemplate.Application.Customers.Commands;

/// <summary>
/// <see cref="ICommandHandler{TCommand,TCommandResult}"/> implementation for creating a new customer entity.
/// </summary>
public class CreateCustomerCommandHandler(
    IUnitOfWorkFactory uowFactory,
    ICustomerWriteRepository repository
) : CustomerCommandHandlerBase(uowFactory, repository), ICommandHandler<CreateCustomerCommand, int>
{
    /// <summary>
    /// Handle the command to create a new customer entity.
    /// </summary>
    /// <param name="command">The <see cref="CreateCustomerCommand"/> to handle.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken" />.</param>
    /// <returns>The id of the newly-created entity.</returns>
    /// <exception cref="InvalidOperationException">Thrown if something unexpected happens.</exception>
    public async Task<int> Handle(
        CreateCustomerCommand command,
        CancellationToken cancellationToken = default
    )
    {
        await using var uow = await _uowFactory.Create(cancellationToken);
        await _repository.Create(command.Customer, uow);
        await uow.Commit(cancellationToken);
        return command.Customer.Id ?? throw new InvalidOperationException("New customer has no Id");
    }
}
