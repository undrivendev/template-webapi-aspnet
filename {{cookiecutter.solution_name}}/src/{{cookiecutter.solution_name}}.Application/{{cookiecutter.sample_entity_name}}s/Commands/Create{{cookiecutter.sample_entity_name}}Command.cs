using HumbleMediator;
using {{cookiecutter.solution_name}}.Core.{{cookiecutter.sample_entity_name}}s;

namespace {{cookiecutter.solution_name}}.Application.{{cookiecutter.sample_entity_name}}s.Commands;

public record Create{{cookiecutter.sample_entity_name}}Command({{cookiecutter.sample_entity_name}} {{cookiecutter.sample_entity_name}}) : ICommand<int>;
