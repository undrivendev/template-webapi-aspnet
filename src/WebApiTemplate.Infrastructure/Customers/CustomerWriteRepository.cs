using WebApiTemplate.Core;
using WebApiTemplate.Core.Customers;
using WebApiTemplate.Infrastructure.Persistence;

namespace WebApiTemplate.Infrastructure.Customers;

public class CustomerWriteRepository : WriteRepositoryBase<Customer>, ICustomerWriteRepository
{
    public CustomerWriteRepository()
        : base() { }
}
