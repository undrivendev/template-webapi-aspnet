using HumbleMediator;
using WebApiTemplate.Core;
using WebApiTemplate.Core.Customers;

namespace WebApiTemplate.Application.Customers.Commands;

public class DeleteCustomerCommandHandler
    : CustomerCommandHandlerBase,
        ICommandHandler<DeleteCustomerCommand, Nothing>
{
    public DeleteCustomerCommandHandler(
        IUnitOfWorkFactory uowFactory,
        ICustomerWriteRepository repository
    )
        : base(uowFactory, repository) { }

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
