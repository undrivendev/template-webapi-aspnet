using HumbleMediator;
using {{cookiecutter.solution_name}}.Application.{{cookiecutter.sample_entity_name}}s.Queries;
using {{cookiecutter.solution_name}}.Core.{{cookiecutter.sample_entity_name}}s;

namespace {{cookiecutter.solution_name}}.Application.{{cookiecutter.sample_entity_name}}s.Queries;

public class Get{{cookiecutter.sample_entity_name}}ByIdQueryHandler : IQueryHandler<Get{{cookiecutter.sample_entity_name}}ByIdQuery, {{cookiecutter.sample_entity_name}}?>
{
    private readonly I{{cookiecutter.sample_entity_name}}ReadRepository _customerReadRepository;

    public Get{{cookiecutter.sample_entity_name}}ByIdQueryHandler(I{{cookiecutter.sample_entity_name}}ReadRepository customerReadRepository)
    {
        _customerReadRepository = customerReadRepository;
    }

    public Task<{{cookiecutter.sample_entity_name}}?> Handle(
        Get{{cookiecutter.sample_entity_name}}ByIdQuery query,
        CancellationToken cancellationToken = default
    ) => _customerReadRepository.GetById(query.Id);
}
