using WebApiTemplate.Core.Customers;

namespace WebApiTemplate.Api.Customers.Requests;

public class UpdateCustomerRequest
{
    public static Customer ToDomainEntity() => new(null);
}
