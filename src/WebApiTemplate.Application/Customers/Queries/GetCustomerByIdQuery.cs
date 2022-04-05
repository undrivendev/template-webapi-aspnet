using WebApiTemplate.Core.Customers;
using WebApiTemplate.Core.Mediator;

namespace WebApiTemplate.Application.Customers.Queries;

public record GetCustomerByIdQuery(Guid Id) : IQuery<Customer>;