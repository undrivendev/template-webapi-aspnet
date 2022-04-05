using WebApiTemplate.Core.Customers.Commands;
using WebApiTemplate.Core.Mediator;

namespace WebApiTemplate.Core.Customers;

public class CustomerCommandHandler
    : ICommandHandler<CreateCustomerCommand, Guid>,
        ICommandHandler<UpdateCustomerCommand, Nothing>,
        ICommandHandler<DeleteCustomerCommand, Nothing>
{
    private readonly IUnitOfWorkFactory _uowFactory;
    private readonly ICustomerWriteRepository _repository;

    public CustomerCommandHandler(IUnitOfWorkFactory uowFactory, ICustomerWriteRepository repository)
    {
        _uowFactory = uowFactory;
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateCustomerCommand command, CancellationToken cancellationToken = default)
    {
        await using var uow = await _uowFactory.Create(cancellationToken);
        await _repository.Create(command.Customer, uow);
        await uow.Commit(cancellationToken);
        return command.Customer.Id ?? throw new InvalidOperationException("New customer has no Id");
    }

    public async Task<Nothing> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken = default)
    {
        await using var uow = await _uowFactory.Create(cancellationToken);
        await _repository.Update(command.Customer, uow);
        await uow.Commit(cancellationToken);
        return Nothing.Instance;
    }

    public async Task<Nothing> Handle(DeleteCustomerCommand command, CancellationToken cancellationToken = default)
    {
        await using var uow = await _uowFactory.Create(cancellationToken);
        await _repository.Delete(command.Id, uow);
        await uow.Commit(cancellationToken);
        return Nothing.Instance;
    }
}