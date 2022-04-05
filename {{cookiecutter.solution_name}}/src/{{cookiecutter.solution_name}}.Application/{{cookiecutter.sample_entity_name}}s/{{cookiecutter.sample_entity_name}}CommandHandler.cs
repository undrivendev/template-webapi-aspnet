using {{cookiecutter.solution_name}}.Application.{{cookiecutter.sample_entity_name}}s.Commands;
using {{cookiecutter.solution_name}}.Core;
using {{cookiecutter.solution_name}}.Core.{{cookiecutter.sample_entity_name}}s;
using {{cookiecutter.solution_name}}.Core.Mediator;

namespace {{cookiecutter.solution_name}}.Application.{{cookiecutter.sample_entity_name}}s;

public class {{cookiecutter.sample_entity_name}}CommandHandler
    : ICommandHandler<Create{{cookiecutter.sample_entity_name}}Command, Guid>,
        ICommandHandler<Update{{cookiecutter.sample_entity_name}}Command, Nothing>,
        ICommandHandler<Delete{{cookiecutter.sample_entity_name}}Command, Nothing>
{
    private readonly IUnitOfWorkFactory _uowFactory;
    private readonly I{{cookiecutter.sample_entity_name}}WriteRepository _repository;

    public {{cookiecutter.sample_entity_name}}CommandHandler(IUnitOfWorkFactory uowFactory, I{{cookiecutter.sample_entity_name}}WriteRepository repository)
    {
        _uowFactory = uowFactory;
        _repository = repository;
    }

    public async Task<Guid> Handle(Create{{cookiecutter.sample_entity_name}}Command command, CancellationToken cancellationToken = default)
    {
        await using var uow = await _uowFactory.Create(cancellationToken);
        await _repository.Create(command.{{cookiecutter.sample_entity_name}}, uow);
        await uow.Commit(cancellationToken);
        return command.{{cookiecutter.sample_entity_name}}.Id ?? throw new InvalidOperationException("New {{cookiecutter.sample_entity_name}} has no Id");
    }

    public async Task<Nothing> Handle(Update{{cookiecutter.sample_entity_name}}Command command, CancellationToken cancellationToken = default)
    {
        await using var uow = await _uowFactory.Create(cancellationToken);
        await _repository.Update(command.{{cookiecutter.sample_entity_name}}, uow);
        await uow.Commit(cancellationToken);
        return Nothing.Instance;
    }

    public async Task<Nothing> Handle(Delete{{cookiecutter.sample_entity_name}}Command command, CancellationToken cancellationToken = default)
    {
        await using var uow = await _uowFactory.Create(cancellationToken);
        await _repository.Delete(command.Id, uow);
        await uow.Commit(cancellationToken);
        return Nothing.Instance;
    }
}