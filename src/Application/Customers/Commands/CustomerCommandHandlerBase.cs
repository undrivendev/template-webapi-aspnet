using WebApiTemplate.Core;
using WebApiTemplate.Core.Customers;

namespace WebApiTemplate.Application.Customers.Commands;

/// <summary>
/// Base class for customer command handlers.
/// </summary>
public abstract class CustomerCommandHandlerBase
{
    /// <summary>
    /// The unit of work factory for creating new unit of work instances.
    /// </summary>
    protected readonly IUnitOfWorkFactory _uowFactory;

    /// <summary>
    /// The customer write repository for manipulating customer entities.
    /// </summary>
    protected readonly ICustomerWriteRepository _repository;

    /// <summary>
    /// Default constructor for the customer command handler base class.
    /// </summary>
    /// <param name="uowFactory"></param>
    /// <param name="repository"></param>
    protected CustomerCommandHandlerBase(
        IUnitOfWorkFactory uowFactory,
        ICustomerWriteRepository repository
    )
    {
        _uowFactory = uowFactory;
        _repository = repository;
    }
}
