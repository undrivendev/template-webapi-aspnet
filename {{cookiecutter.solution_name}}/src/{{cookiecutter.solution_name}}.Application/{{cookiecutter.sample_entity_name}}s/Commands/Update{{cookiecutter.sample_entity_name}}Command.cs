using {{cookiecutter.solution_name}}.Core;
using {{cookiecutter.solution_name}}.Core.{{cookiecutter.sample_entity_name}}s;
using {{cookiecutter.solution_name}}.Core.Mediator;

namespace {{cookiecutter.solution_name}}.Application.{{cookiecutter.sample_entity_name}}s.Commands;

public record Update{{cookiecutter.sample_entity_name}}Command(Guid Id, {{cookiecutter.sample_entity_name}} {{cookiecutter.sample_entity_name}}) : ICommand<Nothing>;