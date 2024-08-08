using HumbleMediator;
using Microsoft.AspNetCore.Mvc;

namespace WebApiTemplate.Api;

/// <summary>
/// Base class for all controllers in the application.
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
public abstract class AppControllerBase(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// The mediator instance.
    /// </summary>
    protected readonly IMediator _mediator = mediator;
}
