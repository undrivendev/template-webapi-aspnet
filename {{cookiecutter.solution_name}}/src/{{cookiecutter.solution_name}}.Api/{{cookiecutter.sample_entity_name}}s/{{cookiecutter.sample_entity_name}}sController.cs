using Microsoft.AspNetCore.Mvc;
using {{cookiecutter.solution_name}}.Api.{{cookiecutter.sample_entity_name}}s.Requests;
using {{cookiecutter.solution_name}}.Api.{{cookiecutter.sample_entity_name}}s.Responses;
using {{cookiecutter.solution_name}}.Application.{{cookiecutter.sample_entity_name}}s.Commands;
using {{cookiecutter.solution_name}}.Application.{{cookiecutter.sample_entity_name}}s.Queries;
using {{cookiecutter.solution_name}}.Core;
using {{cookiecutter.solution_name}}.Core.{{cookiecutter.sample_entity_name}}s;
using {{cookiecutter.solution_name}}.Core.Mediator;

namespace {{cookiecutter.solution_name}}.Api.{{cookiecutter.sample_entity_name}}s;

[Route("[controller]")]
public class {{cookiecutter.sample_entity_name}}sController : AppControllerBase
{
    public {{cookiecutter.sample_entity_name}}sController(IMediator mediator)
        : base(mediator)
    {
    }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult<{{cookiecutter.sample_entity_name}}CreatedResponse>> Create(Create{{cookiecutter.sample_entity_name}}Request request)
    {
        var id = await _mediator.SendCommand<Create{{cookiecutter.sample_entity_name}}Command, Guid>(
            new Create{{cookiecutter.sample_entity_name}}Command(request.ToDomainEntity()));
        return CreatedAtAction(nameof(Get), new { id }, new {{cookiecutter.sample_entity_name}}CreatedResponse(id));
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<ActionResult<{{cookiecutter.sample_entity_name}}>> Get(Guid id)
        => Ok(await _mediator.SendQuery<Get{{cookiecutter.sample_entity_name}}ByIdQuery, {{cookiecutter.sample_entity_name}}>(new Get{{cookiecutter.sample_entity_name}}ByIdQuery(id)));

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, Update{{cookiecutter.sample_entity_name}}Request request)
    {
        await _mediator.SendCommand<Update{{cookiecutter.sample_entity_name}}Command, Nothing>(
            new Update{{cookiecutter.sample_entity_name}}Command(id, request.ToDomainEntity()));
        return NoContent();
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.SendCommand<Delete{{cookiecutter.sample_entity_name}}Command, Nothing>(new Delete{{cookiecutter.sample_entity_name}}Command(id));
        return NoContent();
    }
}