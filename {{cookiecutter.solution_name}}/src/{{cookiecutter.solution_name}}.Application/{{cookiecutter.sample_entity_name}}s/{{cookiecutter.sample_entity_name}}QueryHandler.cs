using {{cookiecutter.solution_name}}.Application.{{cookiecutter.sample_entity_name}}s.Queries;
using {{cookiecutter.solution_name}}.Core.{{cookiecutter.sample_entity_name}}s;
using {{cookiecutter.solution_name}}.Core.Mediator;

namespace {{cookiecutter.solution_name}}.Application.{{cookiecutter.sample_entity_name}}s;

public class {{cookiecutter.sample_entity_name}}QueryHandler : IQueryHandler<Get{{cookiecutter.sample_entity_name}}ByIdQuery, {{cookiecutter.sample_entity_name}}>
{
    private readonly I{{cookiecutter.sample_entity_name}}ReadRepository _{{cookiecutter.sample_entity_name}}ReadRepository;

    public {{cookiecutter.sample_entity_name}}QueryHandler(I{{cookiecutter.sample_entity_name}}ReadRepository {{cookiecutter.sample_entity_name}}ReadRepository)
    {
        _{{cookiecutter.sample_entity_name}}ReadRepository = {{cookiecutter.sample_entity_name}}ReadRepository;
    }

    public Task<{{cookiecutter.sample_entity_name}}> Handle(Get{{cookiecutter.sample_entity_name}}ByIdQuery query, CancellationToken cancellationToken = default)
        => _{{cookiecutter.sample_entity_name}}ReadRepository.GetById(query.Id);
}