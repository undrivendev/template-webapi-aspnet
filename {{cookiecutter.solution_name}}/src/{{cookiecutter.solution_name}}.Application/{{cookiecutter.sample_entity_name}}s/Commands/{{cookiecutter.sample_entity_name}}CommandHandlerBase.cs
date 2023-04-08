using HumbleMediator;
using {{cookiecutter.solution_name}}.Core;
using {{cookiecutter.solution_name}}.Core.{{cookiecutter.sample_entity_name}}s;

namespace {{cookiecutter.solution_name}}.Application.{{cookiecutter.sample_entity_name}}s.Commands;

public abstract class {{cookiecutter.sample_entity_name}}CommandHandlerBase
{
    protected readonly IUnitOfWorkFactory _uowFactory;
    protected readonly I{{cookiecutter.sample_entity_name}}WriteRepository _repository;

    protected {{cookiecutter.sample_entity_name}}CommandHandlerBase(
        IUnitOfWorkFactory uowFactory,
        I{{cookiecutter.sample_entity_name}}WriteRepository repository
    )
    {
        _uowFactory = uowFactory;
        _repository = repository;
    }
}
