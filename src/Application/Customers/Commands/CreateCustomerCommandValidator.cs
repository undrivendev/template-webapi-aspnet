using FluentValidation;

namespace WebApiTemplate.Application.Customers.Commands;

/// <summary>
/// Validator for <see cref="CreateCustomerCommand"/>.
/// </summary>
public sealed class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    /// <summary>
    /// Defines the validation rules for the <see cref="CreateCustomerCommand"/>.
    /// </summary>
    public CreateCustomerCommandValidator()
    {
        RuleFor(e => e.Customer).NotEmpty();
    }
}
