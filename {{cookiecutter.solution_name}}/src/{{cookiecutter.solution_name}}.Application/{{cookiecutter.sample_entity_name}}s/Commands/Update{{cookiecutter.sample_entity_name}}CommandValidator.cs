using FluentValidation;

namespace {{cookiecutter.solution_name}}.Application.{{cookiecutter.sample_entity_name}}s.Commands;

public sealed class Update{{cookiecutter.sample_entity_name}}CommandValidator : AbstractValidator<Update{{cookiecutter.sample_entity_name}}Command>
{
    public Update{{cookiecutter.sample_entity_name}}CommandValidator()
    {
        RuleFor(e => e.Id).Must(e => e > 0);
        RuleFor(e => e.{{cookiecutter.sample_entity_name}}).NotEmpty();
    }
}
