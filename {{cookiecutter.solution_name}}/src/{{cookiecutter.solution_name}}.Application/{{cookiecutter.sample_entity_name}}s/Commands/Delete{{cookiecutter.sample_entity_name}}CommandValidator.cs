using FluentValidation;

namespace {{cookiecutter.solution_name}}.Application.{{cookiecutter.sample_entity_name}}s.Commands;

public sealed class Delete{{cookiecutter.sample_entity_name}}CommandValidator : AbstractValidator<Delete{{cookiecutter.sample_entity_name}}Command>
{
    public Delete{{cookiecutter.sample_entity_name}}CommandValidator()
    {
        RuleFor(e => e.Id).Must(e => e > 0);
    }
}
