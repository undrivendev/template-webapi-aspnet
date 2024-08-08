using HumbleMediator;
using WebApiTemplate.Core;
using WebApiTemplate.Core.Customers;

namespace WebApiTemplate.Application.Customers.Commands;

/// <summary>
/// <see cref="ICommandHandler{TCommand,TCommandResult}"/> implementation for deleting a customer entity.
/// </summary>
public class DeleteCustomerCommandHandler(
    IUnitOfWorkFactory uowFactory,
    ICustomerWriteRepository repository
)
    : CustomerCommandHandlerBase(uowFactory, repository),
        ICommandHandler<DeleteCustomerCommand, Nothing>
{
    /// <summary>
    /// Handle the command to delete a customer entity.
    /// </summary>
    /// <param name="command">The <see cref="DeleteCustomerCommand"/> to handle.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken" />.</param>
    /// <returns>An instance of the <see cref="Nothing" /> class.</returns>
    public async Task<Nothing> Handle(
        DeleteCustomerCommand command,
        CancellationToken cancellationToken = default
    )
    {
        await using var uow = await _uowFactory.Create(cancellationToken);
        await _repository.Delete(command.Id, uow);
        await uow.Commit(cancellationToken);
        return Nothing.Instance;
    }
}
