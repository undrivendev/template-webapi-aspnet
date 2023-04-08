using System.Data.Common;
using WebApiTemplate.Core.Customers;
using WebApiTemplate.Infrastructure.Persistence;

namespace WebApiTemplate.Infrastructure.Customers;

public class CustomerReadRepository : ReadRepositoryBase<Customer>, ICustomerReadRepository
{
    public CustomerReadRepository(DbDataSource db)
        : base(db) { }
}
