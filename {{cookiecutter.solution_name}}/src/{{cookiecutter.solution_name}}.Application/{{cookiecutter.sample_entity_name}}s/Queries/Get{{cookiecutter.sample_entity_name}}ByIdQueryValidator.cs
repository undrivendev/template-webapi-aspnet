using FluentValidation;

namespace {{cookiecutter.solution_name}}.Application.{{cookiecutter.sample_entity_name}}s.Queries;

public sealed class Get{{cookiecutter.sample_entity_name}}ByIdQueryValidator : AbstractValidator<Get{{cookiecutter.sample_entity_name}}ByIdQuery>
{
    public Get{{cookiecutter.sample_entity_name}}ByIdQueryValidator()
    {
        RuleFor(e => e.Id).Must(e => e > 0);
    }
}
