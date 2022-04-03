using Microsoft.Extensions.Options;
using WebApiTemplate.Core.Customers;
using WebApiTemplate.Infrastructure.Persistence;

namespace WebApiTemplate.Infrastructure.Customers;

public class CustomerReadRepository : ReadRepositoryBase<Customer>, ICustomerReadRepository
{
    public CustomerReadRepository(IOptionsMonitor<ReadRepositoryOptions> options)
        : base(options)
    {
    }
}