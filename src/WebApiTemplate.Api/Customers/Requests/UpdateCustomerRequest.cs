using WebApiTemplate.Core.Customers;

namespace WebApiTemplate.Api.Customers.Requests;

public class UpdateCustomerRequest
{
    public Customer ToDomainEntity() => new(null);
}