using FluentValidation;

namespace WebApiTemplate.Application.Customers.Queries;

public sealed class GetCustomerByIdQueryValidator : AbstractValidator<GetCustomerByIdQuery>
{
    public GetCustomerByIdQueryValidator()
    {
        RuleFor(e => e.Id).Must(e => e > 0);
    }
}
