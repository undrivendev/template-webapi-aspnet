using System.ComponentModel.DataAnnotations;

namespace WebApiTemplate.Infrastructure.Persistence;

/// <summary>
/// Options for configuring the repository.
/// </summary>
public class RepositoryOptions
{
    /// <summary>
    /// The connection string to use.
    /// </summary>
    [Required]
    public string? ConnectionString { get; set; }
}
