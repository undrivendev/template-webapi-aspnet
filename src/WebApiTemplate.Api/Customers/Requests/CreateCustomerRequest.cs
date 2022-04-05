using WebApiTemplate.Core.Customers;

namespace WebApiTemplate.Api.Customers.Requests;

public class CreateCustomerRequest
{
    
    public Customer ToDomainEntity() => new(null);
}