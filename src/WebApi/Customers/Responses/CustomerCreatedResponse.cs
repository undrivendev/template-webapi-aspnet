namespace WebApiTemplate.WebApi.Customers.Responses;

/// <summary>
/// Response entity returned to the client after the creation of a Customer entity.
/// </summary>
/// <param name="Id">The ID of the created Customer entity.</param>
public record CustomerCreatedResponse(int Id);
