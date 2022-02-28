using AnimeList.Application.Genres;
using AnimeList.Application.Genres.Commands;
using AnimeList.Application.Genres.Queries;
using AnimeList.Domain.Genres;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace AnimeList.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
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
        var query = new GetGenreByIdQuery(id);
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
    public async Task<IActionResult> Create([FromBody] CreateGenreCommand request)
    {
        var newGenre = await _mediator.Send(request);
        return Created("GetById", newGenre);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Genre), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateGenreCommand request)
    {
        request.Id = id;
        var updatedGenre = await _mediator.Send(request);
        return Ok(updatedGenre);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    public async Task<IActionResult> Delete(int id)
    {
        var query = new DeleteGenreCommand(id);
        _ = await _mediator.Send(query);
        return NoContent();
    }
}
