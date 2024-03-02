using HumbleMediator;
using WebApiTemplate.Application.Customers.Queries;
using WebApiTemplate.Core.Customers;

namespace WebApiTemplate.Application.Customers.Queries;

public class GetCustomerByIdQueryHandler : IQueryHandler<GetCustomerByIdQuery, Customer?>
{
    private readonly ICustomerReadRepository _customerReadRepository;

    public GetCustomerByIdQueryHandler(ICustomerReadRepository customerReadRepository)
    {
        _customerReadRepository = customerReadRepository;
    }

    public Task<Customer?> Handle(
        GetCustomerByIdQuery query,
        CancellationToken cancellationToken = default
    ) => _customerReadRepository.GetById(query.Id);
}
