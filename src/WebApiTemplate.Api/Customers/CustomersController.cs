using HumbleMediator;
using Microsoft.AspNetCore.Mvc;
using WebApiTemplate.Api.Customers.Requests;
using WebApiTemplate.Api.Customers.Responses;
using WebApiTemplate.Application.Customers.Commands;
using WebApiTemplate.Application.Customers.Queries;
using WebApiTemplate.Core;
using WebApiTemplate.Core.Customers;

namespace WebApiTemplate.Api.Customers;

public sealed class CustomersController : AppControllerBase
{
    public CustomersController(IMediator mediator)
        : base(mediator) { }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult<CustomerCreatedResponse>> Create(CreateCustomerRequest request)
    {
        var id = await _mediator.SendCommand<CreateCustomerCommand, int>(
            new CreateCustomerCommand(CreateCustomerRequest.ToDomainEntity())
        );
        return CreatedAtAction(nameof(GetById), new { id }, new CustomerCreatedResponse(id));
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Customer>> GetById(int id)
    {
        var result = await _mediator.SendQuery<GetCustomerByIdQuery, Customer?>(
            new GetCustomerByIdQuery(id)
        );
        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateCustomerRequest request)
    {
        await _mediator.SendCommand<UpdateCustomerCommand, Nothing>(
            new UpdateCustomerCommand(id, UpdateCustomerRequest.ToDomainEntity())
        );
        return NoContent();
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.SendCommand<DeleteCustomerCommand, Nothing>(new DeleteCustomerCommand(id));
        return NoContent();
    }
}
