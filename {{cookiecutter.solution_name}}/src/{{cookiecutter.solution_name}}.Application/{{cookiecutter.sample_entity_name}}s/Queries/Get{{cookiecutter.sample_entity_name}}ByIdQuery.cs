using HumbleMediator;
using {{cookiecutter.solution_name}}.Core.{{cookiecutter.sample_entity_name}}s;

namespace {{cookiecutter.solution_name}}.Application.{{cookiecutter.sample_entity_name}}s.Queries;

public sealed record Get{{cookiecutter.sample_entity_name}}ByIdQuery(int Id) : IQuery<{{cookiecutter.sample_entity_name}}?>;
