using WebApiTemplate.Core.Customers;

namespace WebApiTemplate.Infrastructure.Customers.Persistence;

public class CustomerReadRepository : ICustomerReadRepository
{
    public async Task<Customer> GetById(Guid id)
    {
        throw new NotImplementedException();
    }
}