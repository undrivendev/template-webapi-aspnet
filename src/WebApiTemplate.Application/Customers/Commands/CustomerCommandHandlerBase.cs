using HumbleMediator;
using WebApiTemplate.Core;
using WebApiTemplate.Core.Customers;

namespace WebApiTemplate.Application.Customers.Commands;

public abstract class CustomerCommandHandlerBase
{
    protected readonly IUnitOfWorkFactory _uowFactory;
    protected readonly ICustomerWriteRepository _repository;

    protected CustomerCommandHandlerBase(
        IUnitOfWorkFactory uowFactory,
        ICustomerWriteRepository repository
    )
    {
        _uowFactory = uowFactory;
        _repository = repository;
    }
}
