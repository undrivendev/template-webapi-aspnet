using WebApiTemplate.Core.Customers;

namespace WebApiTemplate.Api.Customers.Requests;

public class CreateCustomerRequest
{
    public static Customer ToDomainEntity() => new(null);
}
