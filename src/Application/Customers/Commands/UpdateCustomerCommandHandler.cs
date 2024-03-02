using HumbleMediator;
using WebApiTemplate.Core;
using WebApiTemplate.Core.Customers;

namespace WebApiTemplate.Application.Customers.Commands;

public class UpdateCustomerCommandHandler
    : CustomerCommandHandlerBase,
        ICommandHandler<UpdateCustomerCommand, Nothing>
{
    public UpdateCustomerCommandHandler(
        IUnitOfWorkFactory uowFactory,
        ICustomerWriteRepository repository
    )
        : base(uowFactory, repository) { }

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
