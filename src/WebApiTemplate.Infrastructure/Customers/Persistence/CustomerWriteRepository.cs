using WebApiTemplate.Core;
using WebApiTemplate.Core.Customers;

namespace WebApiTemplate.Infrastructure.Customers.Persistence;

public class CustomerWriteRepository : ICustomerWriteRepository
{
    public async Task<Guid> Create(Customer entity)
    {
        throw new NotImplementedException();
    }

    public async Task Update(Customer entity)
    {
        throw new NotImplementedException();
    }

    public async Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}