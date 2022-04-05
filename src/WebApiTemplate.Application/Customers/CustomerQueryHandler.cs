using WebApiTemplate.Application.Customers.Queries;
using WebApiTemplate.Core.Customers;
using WebApiTemplate.Core.Mediator;

namespace WebApiTemplate.Application.Customers;

public class CustomerQueryHandler : IQueryHandler<GetCustomerByIdQuery, Customer>
{
    private readonly ICustomerReadRepository _customerReadRepository;

    public CustomerQueryHandler(ICustomerReadRepository customerReadRepository)
    {
        _customerReadRepository = customerReadRepository;
    }

    public Task<Customer> Handle(GetCustomerByIdQuery query, CancellationToken cancellationToken = default)
        => _customerReadRepository.GetById(query.Id);
}