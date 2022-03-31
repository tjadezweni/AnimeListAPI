using AnimeListAPI.Application.Commands.CreateGenre;
using AnimeListAPI.Application.Commands.DeleteGenre;
using AnimeListAPI.Application.Commands.UpdateGenre;
using AnimeListAPI.Application.Queries.GetAllGenres;
using AnimeListAPI.Application.Queries.GetGenreById;
using AnimeListAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace AnimeList.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class GenresController : ControllerBase
{
    private readonly IMediator _mediator;

    public GenresController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Genre), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetGenreByIdQuery()
        {
            Id = id
        };
        var genre = await _mediator.Send(query);
        return genre is null ? NotFound() : Ok(genre);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Genre>), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllGenresQuery();
        var genresList = await _mediator.Send(query);
        return Ok(genresList);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Genre), 201)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] Genre genre)
    {
        var command = new CreateGenreCommand()
        {
            Genre = genre
        };
        var newGenre = await _mediator.Send(command);
        return Created("GetById", newGenre);
    }

    [HttpPut]
    [ProducesResponseType(typeof(Genre), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update([FromBody] Genre genre)
    {
        var command = new UpdateGenreCommand()
        {
            Genre = genre
        };
        var updatedGenre = await _mediator.Send(command);
        return Ok(updatedGenre);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    public async Task<IActionResult> Delete(int id)
    {
        var query = new DeleteGenreCommand()
        {
            Id = id
        };
        _ = await _mediator.Send(query);
        return NoContent();
    }
}
