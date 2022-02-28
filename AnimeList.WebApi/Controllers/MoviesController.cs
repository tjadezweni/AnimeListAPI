using AnimeList.Application.Movies;
using AnimeList.Application.Movies.Commands;
using AnimeList.Application.Movies.Queries;
using AnimeList.Domain.Movies;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimeList.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MoviesController : ControllerBase
{
    private readonly IMediator _mediator;

    public MoviesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Movie), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var query = new GetMovieByIdQuery(id);
        var movie = await _mediator.Send(query);
        return movie is null ? NotFound() : Ok(movie);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Movie>), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get()
    {
        var query = new GetAllMoviesQuery();
        var moviesList = await _mediator.Send(query);
        return Ok(moviesList);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Movie), 201)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] CreateMovieCommand request)
    {
        var newMovie = await _mediator.Send(request);
        return Created("GetById", newMovie);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Movie), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateMovieCommand request)
    {
        request.Id = id;
        var updatedMovie = await _mediator.Send(request);
        return Ok(updatedMovie);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    public async Task<IActionResult> Delete(int id)
    {
        var query = new DeleteMovieCommand(id);
        _ = await _mediator.Send(query);
        return NoContent();
    }
}
