using AnimeList.Application.Studios;
using AnimeList.Application.Studios.Commands;
using AnimeList.Application.Studios.Queries;
using AnimeList.Domain.Helpers;
using AnimeList.Domain.Studios;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace AnimeList.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class StudiosController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudiosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Studio), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetStudioByIdQuery(id);
        var studio = await _mediator.Send(query);
        return studio is null ? NotFound() : Ok(studio);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Studio>), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllStudiosQuery();
        var studiosList = await _mediator.Send(query);
        return Ok(studiosList);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Studio), 201)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateStudioCommand request)
    {
        var newStudio = await _mediator.Send(request);
        return Created("GetById", newStudio);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Studio), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateStudioCommand request)
    {
        request.Id = id;
        var updatedStudio = await _mediator.Send(request);
        return Ok(updatedStudio);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    public async Task<IActionResult> Delete(int id)
    {
        var query = new DeleteStudioCommand(id);
        _ = await _mediator.Send(query);
        return NoContent();
    }
}
