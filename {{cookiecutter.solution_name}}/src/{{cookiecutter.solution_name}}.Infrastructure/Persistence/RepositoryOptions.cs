using System.ComponentModel.DataAnnotations;

namespace {{cookiecutter.solution_name}}.Infrastructure.Persistence;

public class RepositoryOptions
{
    [Required]
    public string? ConnectionString { get; set; }
}
