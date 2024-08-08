using WebApiTemplate.Core.Customers;

namespace WebApiTemplate.WebApi.Customers.Requests;

/// <summary>
/// Request entity for creating a customer.
/// </summary>
public class CreateCustomerRequest
{
    /// <summary>
    /// Maps the request to a domain entity.
    /// </summary>
    /// <returns>The domain entity.</returns>
    public static Customer ToDomainEntity() => new(null);
}
