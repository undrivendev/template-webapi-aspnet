using Microsoft.AspNetCore.Mvc;
using WebApiTemplate.Core.Mediator;

namespace WebApiTemplate.Api;

[ApiController]
public abstract class ApiBaseController : ControllerBase
{
    protected readonly IMediator _mediator;

    public ApiBaseController(IMediator mediator)
    {
        _mediator = mediator;
    }
}