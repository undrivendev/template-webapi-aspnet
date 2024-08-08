namespace WebApiTemplate.Core.Customers;

/// <summary>
/// Customer entity.
/// </summary>
/// <param name="Id"><inheritdoc /></param>
public record Customer(int? Id) : BaseEntity(Id);
