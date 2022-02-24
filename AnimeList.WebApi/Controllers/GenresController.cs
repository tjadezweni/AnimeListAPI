using AnimeList.Application.Genres;
using AnimeList.Domain.Genres;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnimeList.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class GenresController : ControllerBase
{
    private readonly IGenreService genreService;

    public GenresController(IGenreService genreService)
    {
        this.genreService = genreService;
    }

    // GET: api/<SeriesController>/1
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Genre), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var genre = await genreService.GetById(id);
        return Ok(genre);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Genre>), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get()
    {
        var genresList = await genreService.Get();
        return Ok(genresList);
    }

    // POST api/<SeriesController>
    [HttpPost]
    [ProducesResponseType(typeof(Genre), 201)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] Genre newGenre)
    {
        await genreService.Create(newGenre);
        return Created("", newGenre);
    }

    // PUT api/<SeriesController>/5
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Genre), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] Genre updatedGenre)
    {
        updatedGenre.Id = id;
        updatedGenre = await genreService.Update(updatedGenre);
        return Ok(updatedGenre);
    }

    // DELETE api/<SeriesController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    public async Task<IActionResult> Delete(int id)
    {
        await genreService.Delete(id);
        return NoContent();
    }
}
