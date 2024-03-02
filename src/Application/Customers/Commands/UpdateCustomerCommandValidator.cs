using FluentValidation;

namespace WebApiTemplate.Application.Customers.Commands;

public sealed class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
        RuleFor(e => e.Id).Must(e => e > 0);
        RuleFor(e => e.Customer).NotEmpty();
    }
}
