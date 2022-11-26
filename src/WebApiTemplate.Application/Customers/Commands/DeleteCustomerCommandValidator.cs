using FluentValidation;

namespace WebApiTemplate.Application.Customers.Commands;

public sealed class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
{
    public DeleteCustomerCommandValidator()
    {
        RuleFor(e => e.Id).Must(e => e > 0);
    }
}
