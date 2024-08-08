using FluentValidation;

namespace WebApiTemplate.Application.Validation;

/// <summary>
/// Base class for validation decorators.
/// </summary>
/// <typeparam name="TRequest"></typeparam>
public abstract class BaseValidationDecorator<TRequest>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseValidationDecorator{TRequest}"/> class.
    /// </summary>
    /// <param name="validators"></param>
    protected BaseValidationDecorator(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    /// <summary>
    /// Validates the request.
    /// </summary>
    /// <param name="request">The request to validate.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
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
