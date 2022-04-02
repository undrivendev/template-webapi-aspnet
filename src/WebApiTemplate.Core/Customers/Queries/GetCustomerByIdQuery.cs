using WebApiTemplate.Core.Mediator;

namespace WebApiTemplate.Core.Customers.Queries;

public record GetCustomerByIdQuery(Guid Id) : IQuery<Customer>;