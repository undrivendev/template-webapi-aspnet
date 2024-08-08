using HumbleMediator;
using WebApiTemplate.Core.Customers;

namespace WebApiTemplate.Application.Customers.Queries;

/// <summary>
/// Query to get a <see cref="Customer"/> by its id.
/// </summary>
public class GetCustomerByIdQueryHandler : IQueryHandler<GetCustomerByIdQuery, Customer?>
{
    private readonly ICustomerReadRepository _customerReadRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetCustomerByIdQueryHandler"/> class.
    /// </summary>
    /// <param name="customerReadRepository"></param>
    public GetCustomerByIdQueryHandler(ICustomerReadRepository customerReadRepository)
    {
        _customerReadRepository = customerReadRepository;
    }

    /// <summary>
    /// Handles the <see cref="GetCustomerByIdQuery"/>.
    /// </summary>
    /// <param name="query">The query to handle.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns></returns>
    public Task<Customer?> Handle(
        GetCustomerByIdQuery query,
        CancellationToken cancellationToken = default
    ) => _customerReadRepository.GetById(query.Id);
}
