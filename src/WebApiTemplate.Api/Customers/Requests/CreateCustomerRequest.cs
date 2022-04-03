using WebApiTemplate.Core.Customers;

namespace WebApiTemplate.Api.Customers.Requests;

public class CreateCustomerRequest
{
    public Guid Id { get; set; }
    
    public Customer ToDomainEntity() => new(Id);
}