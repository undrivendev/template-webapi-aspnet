using FluentValidation;

namespace WebApiTemplate.Application.Validation;

public abstract class BaseValidationDecorator<TRequest>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    protected BaseValidationDecorator(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    protected async Task Validate(TRequest request, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return;
        }

        foreach (var validator in _validators)
        {
            await validator.ValidateAndThrowAsync(request, cancellationToken);
        }
    }
}
