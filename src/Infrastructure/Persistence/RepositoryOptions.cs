using System.ComponentModel.DataAnnotations;

namespace WebApiTemplate.Infrastructure.Persistence;

public class RepositoryOptions
{
    [Required]
    public string? ConnectionString { get; set; }
}
