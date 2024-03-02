using FluentValidation;

namespace WebApiTemplate.Application.Customers.Commands;

public sealed class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(e => e.Customer).NotEmpty();
    }
}
