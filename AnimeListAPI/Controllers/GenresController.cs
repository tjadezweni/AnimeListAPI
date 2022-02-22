using AnimeListAPI.Dto;
using AnimeListAPI.Models;
using AnimeListAPI.Repositories;
using AnimeListAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnimeListAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GenresController : ControllerBase
{
    private readonly IGenresRepository genresRepository;
    public GenresController(IGenresRepository genresRepository) : base()
    {
        this.genresRepository = genresRepository;
    }

    // GET api/<GenresController>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var genresList = await genresRepository.GetAllAsync();
        return Ok(genresList);
    }

    // GET api/<GenresController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var genre = await genresRepository.GetAsync(id);
        return Ok(genre);
    }

    // POST api/<GenresController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] GenreDTO newGenre)
    {
        var existingGenre = await genresRepository.GetAsync(newGenre.Id);
        if (existingGenre is not null)
        {
            return BadRequest(ErrorMessages.IdFound("genre"));
        }
        var genre = new Genre()
        {
            Id = newGenre.Id,
            Name = newGenre.Name,
        };
        await genresRepository.CreateAsync(genre);
        return Created($"/api/Genres/{newGenre.Id}", newGenre);
    }

    // PUT api/<GenresController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] GenreDTO updatedGenre)
    {
        var existingGenre = await genresRepository.GetAsync(id);
        if (existingGenre is null)
        {
            return BadRequest(ErrorMessages.IdNotFound("genre"));
        }
        existingGenre.Name = updatedGenre.Name;
        await genresRepository.UpdateAsync(existingGenre);
        return Ok(updatedGenre);
    }

    // DELETE api/<GenresController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var existingGenre = await genresRepository.GetAsync(id);
        if (existingGenre is null)
        {
            return BadRequest(ErrorMessages.IdNotFound("genre"));
        }
        await genresRepository.DeleteAsync(id);
        return NoContent();
    }
}
