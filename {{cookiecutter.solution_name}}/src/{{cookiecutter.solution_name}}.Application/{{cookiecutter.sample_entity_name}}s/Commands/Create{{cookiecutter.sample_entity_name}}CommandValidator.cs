using FluentValidation;

namespace {{cookiecutter.solution_name}}.Application.{{cookiecutter.sample_entity_name}}s.Commands;

public sealed class Create{{cookiecutter.sample_entity_name}}CommandValidator : AbstractValidator<Create{{cookiecutter.sample_entity_name}}Command>
{
    public Create{{cookiecutter.sample_entity_name}}CommandValidator()
    {
        RuleFor(e => e.{{cookiecutter.sample_entity_name}}).NotEmpty();
    }
}
