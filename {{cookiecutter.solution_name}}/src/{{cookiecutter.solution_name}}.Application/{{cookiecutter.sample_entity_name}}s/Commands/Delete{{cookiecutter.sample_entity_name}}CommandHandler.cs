using HumbleMediator;
using {{cookiecutter.solution_name}}.Core;
using {{cookiecutter.solution_name}}.Core.{{cookiecutter.sample_entity_name}}s;

namespace {{cookiecutter.solution_name}}.Application.{{cookiecutter.sample_entity_name}}s.Commands;

public class Delete{{cookiecutter.sample_entity_name}}CommandHandler
    : {{cookiecutter.sample_entity_name}}CommandHandlerBase,
        ICommandHandler<Delete{{cookiecutter.sample_entity_name}}Command, Nothing>
{
    public Delete{{cookiecutter.sample_entity_name}}CommandHandler(
        IUnitOfWorkFactory uowFactory,
        I{{cookiecutter.sample_entity_name}}WriteRepository repository
    )
        : base(uowFactory, repository) { }

    public async Task<Nothing> Handle(
        Delete{{cookiecutter.sample_entity_name}}Command command,
        CancellationToken cancellationToken = default
    )
    {
        await using var uow = await _uowFactory.Create(cancellationToken);
        await _repository.Delete(command.Id, uow);
        await uow.Commit(cancellationToken);
        return Nothing.Instance;
    }
}
