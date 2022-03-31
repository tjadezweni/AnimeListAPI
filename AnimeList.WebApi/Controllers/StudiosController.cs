using AnimeListAPI.Application.Commands.CreateStudio;
using AnimeListAPI.Application.Commands.DeleteStudio;
using AnimeListAPI.Application.Commands.UpdateStudio;
using AnimeListAPI.Application.Queries.GetAllStudios;
using AnimeListAPI.Application.Queries.GetStudioById;
using AnimeListAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace AnimeList.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        var query = new GetStudioByIdQuery()
        {
            Id = id
        };
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
    public async Task<IActionResult> Create([FromBody] Studio studio)
    {
        var command = new CreateStudioCommand()
        {
            Studio = studio
        };
        var newStudio = await _mediator.Send(command);
        return Created("GetById", newStudio);
    }

    [HttpPut]
    [ProducesResponseType(typeof(Studio), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update([FromBody] Studio studio)
    {
        var command = new UpdateStudioCommand()
        {
            Studio = studio
        };
        var updatedStudio = await _mediator.Send(command);
        return Ok(updatedStudio);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    public async Task<IActionResult> Delete(int id)
    {
        var query = new DeleteStudioCommand()
        {
            Id = id
        };
        _ = await _mediator.Send(query);
        return NoContent();
    }
}
