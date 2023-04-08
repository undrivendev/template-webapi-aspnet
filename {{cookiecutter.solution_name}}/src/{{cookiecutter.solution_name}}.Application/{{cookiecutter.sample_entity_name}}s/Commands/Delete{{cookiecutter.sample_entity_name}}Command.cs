using HumbleMediator;
using {{cookiecutter.solution_name}}.Core;

namespace {{cookiecutter.solution_name}}.Application.{{cookiecutter.sample_entity_name}}s.Commands;

public record Delete{{cookiecutter.sample_entity_name}}Command(int Id) : ICommand<Nothing>;
