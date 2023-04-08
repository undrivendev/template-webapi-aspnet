using {{cookiecutter.solution_name}}.Core.{{cookiecutter.sample_entity_name}}s;

namespace {{cookiecutter.solution_name}}.Api.{{cookiecutter.sample_entity_name}}s.Requests;

public class Create{{cookiecutter.sample_entity_name}}Request
{
    public static {{cookiecutter.sample_entity_name}} ToDomainEntity() => new(null);
}
