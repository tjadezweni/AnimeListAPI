using AnimeListAPI.Dto;
using AnimeListAPI.Models;
using AnimeListAPI.Repositories;
using AnimeListAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnimeListAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MoviesController : ControllerBase
{
    private readonly IMoviesRepository moviesRepository;

    private readonly IGenresRepository genresRepository;

    private readonly IStudiosRepository studiosRepository;

    public MoviesController(
        IMoviesRepository moviesRepository,
        IGenresRepository genresRepository,
        IStudiosRepository studiosRepository)
        : base()
    {
        this.moviesRepository = moviesRepository;
        this.genresRepository = genresRepository;
        this.studiosRepository = studiosRepository;
    }

    // GET: api/<MoviesController>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var moviesList = await moviesRepository.GetAllAsync();
        return Ok(moviesList);
    }

    // GET api/<MoviesController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var movie = await moviesRepository.GetAsync(id);
        return Ok(movie);
    }

    // POST api/<MoviesController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] MovieDTO newMovie)
    {
        var existingMovie = await moviesRepository.GetAsync(newMovie.Id);
        if (existingMovie is not null)
        {
            return BadRequest(ErrorMessages.IdFound("movie"));
        }
        var movie = new Movie()
        {
            Id = newMovie.Id,
            Title = newMovie.Title,
            YearReleased = newMovie.YearReleased
        };
        await moviesRepository.CreateAsync(movie);
        return Created($"/api/Movies/{movie.Id}", movie);
    }

    // PUT api/<MoviesController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] MovieDTO updatedMovie)
    {
        var existingMovie = await moviesRepository.GetAsync(id);
        if (existingMovie is null)
        {
            return BadRequest(ErrorMessages.IdNotFound("movie"));
        }
        existingMovie.Title = updatedMovie.Title;
        existingMovie.YearReleased = updatedMovie.YearReleased;
        await moviesRepository.UpdateAsync(existingMovie);
        return Ok(updatedMovie);
    }

    // PUT api/<MoviesController>/Genres/
    [HttpPut("{id}/Genres/")]
    public async Task<IActionResult> Put(Guid id, [FromBody] AddGenreDTO addGenre)
    {
        var existingMovies = await moviesRepository.GetAsync(id);
        var existingGenre = await genresRepository.GetAsync(addGenre.GenreId);
        if (existingMovies is null || existingGenre is null)
        {
            return BadRequest(ErrorMessages.IdNotFound("series / genre"));
        }
        existingMovies.Genre = existingGenre;
        await moviesRepository.UpdateAsync(existingMovies);
        return Ok(existingMovies);
    }

    [HttpPut("{id}/Studios/")]
    public async Task<IActionResult> Put(Guid id, [FromBody] AddStudioDTO addStudio)
    {
        var existingMovies = await moviesRepository.GetAsync(id);
        var existingStudio = await studiosRepository.GetAsync(addStudio.StudioId);
        if (existingStudio is null || existingMovies is null)
        {
            return BadRequest(ErrorMessages.IdNotFound("series / studio"));
        }
        existingMovies.Studio = existingStudio;
        await moviesRepository.UpdateAsync(existingMovies);
        return Ok(existingMovies);
    }

    // DELETE api/<MoviesController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var existingMovie = await moviesRepository.GetAsync(id);
        if (existingMovie is null)
        {
            return BadRequest(ErrorMessages.IdNotFound("movie"));
        }
        await moviesRepository.DeleteAsync(id);
        return NoContent();
    }
}
