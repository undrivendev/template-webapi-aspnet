using Microsoft.AspNetCore.Mvc;
using WebApiTemplate.Api.Customers.Requests;
using WebApiTemplate.Api.Customers.Responses;
using WebApiTemplate.Core;
using WebApiTemplate.Core.Customers;
using WebApiTemplate.Core.Customers.Commands;
using WebApiTemplate.Core.Customers.Queries;
using WebApiTemplate.Core.Mediator;

namespace WebApiTemplate.Api.Customers;

[Route("[controller]")]
public class CustomersController : AppControllerBase
{
    public CustomersController(IMediator mediator)
        : base(mediator)
    {
    }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult<CustomerCreatedResponse>> Create(CreateCustomerRequest request)
    {
        var id = await _mediator.SendCommand<CreateCustomerCommand, Guid>(
            new CreateCustomerCommand(request.ToDomainEntity()));
        return CreatedAtAction(nameof(Get), new { id }, new CustomerCreatedResponse(id));
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<ActionResult<Customer>> Get(Guid id)
        => Ok(await _mediator.SendQuery<GetCustomerByIdQuery, Customer>(new GetCustomerByIdQuery(id)));

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateCustomerRequest request)
    {
        await _mediator.SendCommand<UpdateCustomerCommand, Nothing>(
            new UpdateCustomerCommand(id, request.ToDomainEntity()));
        return NoContent();
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.SendCommand<DeleteCustomerCommand, Nothing>(new DeleteCustomerCommand(id));
        return NoContent();
    }
}