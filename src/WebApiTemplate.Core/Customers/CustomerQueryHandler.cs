using WebApiTemplate.Core.Customers.Queries;
using WebApiTemplate.Core.Mediator;

namespace WebApiTemplate.Core.Customers;

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