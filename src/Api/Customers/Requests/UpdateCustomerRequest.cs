using WebApiTemplate.Core.Customers;

namespace WebApiTemplate.Api.Customers.Requests;

/// <summary>
/// Request entity for updating a customer.
/// </summary>
public class UpdateCustomerRequest
{
    /// <summary>
    /// Maps the request to a domain entity.
    /// </summary>
    /// <returns>The domain entity.</returns>
    public static Customer ToDomainEntity() => new(null);
}
