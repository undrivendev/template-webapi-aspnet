using System.Data.Common;
using WebApiTemplate.Core.Customers;
using WebApiTemplate.Infrastructure.Persistence;

namespace WebApiTemplate.Infrastructure.Customers;

/// <summary>
/// Repository for reading <see cref="Customer"/> entities.
/// </summary>
public class CustomerReadRepository : ReadRepositoryBase<Customer>, ICustomerReadRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CustomerReadRepository"/> class.
    /// </summary>
    /// <param name="db"></param>
    public CustomerReadRepository(DbDataSource db)
        : base(db) { }
}
