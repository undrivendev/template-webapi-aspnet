using HumbleMediator;
using WebApiTemplate.Core.Customers;

namespace WebApiTemplate.Application.Customers.Queries;

/// <summary>
/// Query to get a <see cref="Customer"/> by its id.
/// </summary>
/// <param name="Id"></param>
public sealed record GetCustomerByIdQuery(int Id) : IQuery<Customer?>;
