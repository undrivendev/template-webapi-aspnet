using HumbleMediator;
using {{cookiecutter.solution_name}}.Core;
using {{cookiecutter.solution_name}}.Core.{{cookiecutter.sample_entity_name}}s;

namespace {{cookiecutter.solution_name}}.Application.{{cookiecutter.sample_entity_name}}s.Commands;

public class Create{{cookiecutter.sample_entity_name}}CommandHandler
    : {{cookiecutter.sample_entity_name}}CommandHandlerBase,
        ICommandHandler<Create{{cookiecutter.sample_entity_name}}Command, int>
{
    public Create{{cookiecutter.sample_entity_name}}CommandHandler(
        IUnitOfWorkFactory uowFactory,
        I{{cookiecutter.sample_entity_name}}WriteRepository repository
    )
        : base(uowFactory, repository) { }

    public async Task<int> Handle(
        Create{{cookiecutter.sample_entity_name}}Command command,
        CancellationToken cancellationToken = default
    )
    {
        await using var uow = await _uowFactory.Create(cancellationToken);
        await _repository.Create(command.{{cookiecutter.sample_entity_name}}, uow);
        await uow.Commit(cancellationToken);
        return command.{{cookiecutter.sample_entity_name}}.Id ?? throw new InvalidOperationException("New customer has no Id");
    }
}
