using AnimeList.Application.Genres;
using AnimeList.Domain.Genres;
using Microsoft.AspNetCore.Mvc;


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

    [HttpPost]
    [ProducesResponseType(typeof(Genre), 201)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] Genre newGenre)
    {
        await genreService.Create(newGenre);
        return Created("", newGenre);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Genre), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] Genre updatedGenre)
    {
        updatedGenre.Id = id;
        updatedGenre = await genreService.Update(updatedGenre);
        return Ok(updatedGenre);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    public async Task<IActionResult> Delete(int id)
    {
        await genreService.Delete(id);
        return NoContent();
    }
}
