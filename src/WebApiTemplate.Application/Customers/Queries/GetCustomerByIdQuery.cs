using HumbleMediator;
using WebApiTemplate.Core.Customers;

namespace WebApiTemplate.Application.Customers.Queries;

public record GetCustomerByIdQuery(int Id) : IQuery<Customer>;
