using AnimeList.Application.Movies;
using AnimeList.Domain.Movies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimeList.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MoviesController : ControllerBase
{
    private readonly IMovieService movieService;

    public MoviesController(IMovieService movieService)
    {
        this.movieService = movieService;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Movie), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var movie = await movieService.GetById(id);
        return Ok(movie);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Movie>), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get()
    {
        var moviesList = await movieService.Get();
        return Ok(moviesList);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Movie), 201)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] Movie newMovie)
    {
        await movieService.Create(newMovie);
        return Created("", newMovie);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Movie), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] Movie updatedMovie)
    {
        updatedMovie.Id = id;
        updatedMovie = await movieService.Update(updatedMovie);
        return Ok(updatedMovie);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    public async Task<IActionResult> Delete(int id)
    {
        await movieService.Delete(id);
        return NoContent();
    }
}
