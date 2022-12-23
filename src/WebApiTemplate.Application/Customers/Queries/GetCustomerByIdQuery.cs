using HumbleMediator;
using WebApiTemplate.Core.Customers;

namespace WebApiTemplate.Application.Customers.Queries;

public sealed record GetCustomerByIdQuery(int Id) : IQuery<Customer?>;
