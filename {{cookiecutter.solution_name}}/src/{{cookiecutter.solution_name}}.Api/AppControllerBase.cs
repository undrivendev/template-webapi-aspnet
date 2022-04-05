using Microsoft.AspNetCore.Mvc;
using {{cookiecutter.solution_name}}.Core.Mediator;

namespace {{cookiecutter.solution_name}}.Api;

[ApiController]
public abstract class AppControllerBase : ControllerBase
{
    protected readonly IMediator _mediator;

    public AppControllerBase(IMediator mediator)
    {
        _mediator = mediator;
    }
}