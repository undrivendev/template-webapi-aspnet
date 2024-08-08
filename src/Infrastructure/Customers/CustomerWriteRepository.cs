using WebApiTemplate.Core.Customers;
using WebApiTemplate.Infrastructure.Persistence;

namespace WebApiTemplate.Infrastructure.Customers;

/// <summary>
/// Repository for writing <see cref="Customer"/> entities.
/// </summary>
public class CustomerWriteRepository : WriteRepositoryBase<Customer>, ICustomerWriteRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CustomerWriteRepository"/> class.
    /// </summary>
    public CustomerWriteRepository()
        : base() { }
}
