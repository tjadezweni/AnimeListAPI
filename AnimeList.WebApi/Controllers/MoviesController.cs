using AnimeListAPI.Application.Commands.CreateMovie;
using AnimeListAPI.Application.Commands.DeleteMovie;
using AnimeListAPI.Application.Commands.UpdateMovie;
using AnimeListAPI.Application.Queries.GetAllMovies;
using AnimeListAPI.Application.Queries.GetMovieById;
using AnimeListAPI.Domain.Entities;
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
        var query = new GetMovieByIdQuery()
        {
            Id = id
        };
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
    public async Task<IActionResult> Post([FromBody] Movie movie)
    {
        var command = new CreateMovieCommand()
        {
            Movie = movie
        };
        var newMovie = await _mediator.Send(command);
        return Created("GetById", newMovie);
    }

    [HttpPut]
    [ProducesResponseType(typeof(Movie), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put([FromBody] Movie movie)
    {
        var command = new UpdateMovieCommand()
        {
            Movie = movie
        };
        var updatedMovie = await _mediator.Send(command);
        return Ok(updatedMovie);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    public async Task<IActionResult> Delete(int id)
    {
        var query = new DeleteMovieCommand()
        {
            Id = id
        };
        _ = await _mediator.Send(query);
        return NoContent();
    }
}
