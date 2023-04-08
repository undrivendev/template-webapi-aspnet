using HumbleMediator;
using Microsoft.AspNetCore.Mvc;
using {{cookiecutter.solution_name}}.Api.{{cookiecutter.sample_entity_name}}s.Requests;
using {{cookiecutter.solution_name}}.Api.{{cookiecutter.sample_entity_name}}s.Responses;
using {{cookiecutter.solution_name}}.Application.{{cookiecutter.sample_entity_name}}s.Commands;
using {{cookiecutter.solution_name}}.Application.{{cookiecutter.sample_entity_name}}s.Queries;
using {{cookiecutter.solution_name}}.Core;
using {{cookiecutter.solution_name}}.Core.{{cookiecutter.sample_entity_name}}s;

namespace {{cookiecutter.solution_name}}.Api.{{cookiecutter.sample_entity_name}}s;

public sealed class {{cookiecutter.sample_entity_name}}sController : AppControllerBase
{
    public {{cookiecutter.sample_entity_name}}sController(IMediator mediator)
        : base(mediator) { }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult<{{cookiecutter.sample_entity_name}}CreatedResponse>> Create(Create{{cookiecutter.sample_entity_name}}Request request)
    {
        var id = await _mediator.SendCommand<Create{{cookiecutter.sample_entity_name}}Command, int>(
            new Create{{cookiecutter.sample_entity_name}}Command(Create{{cookiecutter.sample_entity_name}}Request.ToDomainEntity())
        );
        return CreatedAtAction(nameof(GetById), new { id }, new {{cookiecutter.sample_entity_name}}CreatedResponse(id));
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<{{cookiecutter.sample_entity_name}}>> GetById(int id)
    {
        var result = await _mediator.SendQuery<Get{{cookiecutter.sample_entity_name}}ByIdQuery, {{cookiecutter.sample_entity_name}}?>(
            new Get{{cookiecutter.sample_entity_name}}ByIdQuery(id)
        );
        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update(int id, Update{{cookiecutter.sample_entity_name}}Request request)
    {
        await _mediator.SendCommand<Update{{cookiecutter.sample_entity_name}}Command, Nothing>(
            new Update{{cookiecutter.sample_entity_name}}Command(id, Update{{cookiecutter.sample_entity_name}}Request.ToDomainEntity())
        );
        return NoContent();
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.SendCommand<Delete{{cookiecutter.sample_entity_name}}Command, Nothing>(new Delete{{cookiecutter.sample_entity_name}}Command(id));
        return NoContent();
    }
}
