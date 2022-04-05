using {{cookiecutter.solution_name}}.Core.{{cookiecutter.sample_entity_name}}s;
using {{cookiecutter.solution_name}}.Core.Mediator;

namespace {{cookiecutter.solution_name}}.Application.{{cookiecutter.sample_entity_name}}s.Queries;

public record Get{{cookiecutter.sample_entity_name}}ByIdQuery(Guid Id) : IQuery<{{cookiecutter.sample_entity_name}}>;