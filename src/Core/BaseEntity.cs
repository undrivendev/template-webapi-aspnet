namespace WebApiTemplate.Core;

/// <summary>
/// Base class for all domain entities.
/// </summary>
/// <param name="Id">The id of the entity.</param>
public abstract record BaseEntity(int? Id);
