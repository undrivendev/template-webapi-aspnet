using HumbleMediator;
using WebApiTemplate.Core;
using WebApiTemplate.Core.Customers;

namespace WebApiTemplate.Application.Customers.Commands;

/// <summary>
/// Command handler for updating a <see cref="Customer"/>.
/// </summary>
/// <param name="uowFactory">The factory to create new instances of <see cref="IUnitOfWork"/>.</param>
/// <param name="repository">The repository for writing <see cref="Customer"/> entities.</param>
public class UpdateCustomerCommandHandler(
    IUnitOfWorkFactory uowFactory,
    ICustomerWriteRepository repository
)
    : CustomerCommandHandlerBase(uowFactory, repository),
        ICommandHandler<UpdateCustomerCommand, Nothing>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateCustomerCommandHandler"/> class.
    /// </summary>
    /// <param name="command">The command to handle.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns></returns>
    public async Task<Nothing> Handle(
        UpdateCustomerCommand command,
        CancellationToken cancellationToken = default
    )
    {
        await using var uow = await _uowFactory.Create(cancellationToken);
        await _repository.Update(command.Customer, uow);
        await uow.Commit(cancellationToken);
        return Nothing.Instance;
    }
}
