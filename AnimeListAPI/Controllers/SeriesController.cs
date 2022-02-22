using AnimeListAPI.Dto;
using AnimeListAPI.Models;
using AnimeListAPI.Repositories;
using AnimeListAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnimeListAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SeriesController : ControllerBase
{
    private readonly ISeriesRepository seriesRepository;

    private readonly IGenresRepository genresRepository;

    private readonly IStudiosRepository studiosRepository;

    public SeriesController(
        ISeriesRepository seriesRepository,
        IGenresRepository genresRepository,
        IStudiosRepository studiosRepository)
        : base()
    {
        this.seriesRepository = seriesRepository;
        this.genresRepository = genresRepository;
        this.studiosRepository = studiosRepository;
    }

    // GET: api/<SeriesController>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var seriesList = await seriesRepository.GetAllAsync();
        return Ok(seriesList);
    }

    // GET api/<SeriesController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var series = await seriesRepository.GetAsync(id);
        return Ok(series);
    }

    // POST api/<SeriesController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] SeriesDTO newSeries)
    {
        var existingSeries = await seriesRepository.GetAsync(newSeries.Id);
        if (existingSeries is not null)
        {
            return BadRequest(ErrorMessages.IdFound("series"));
        }
        var series = new Series()
        {
            Id = newSeries.Id,
            Title = newSeries.Title,
            Seasons = newSeries.Seasons,
            Episodes = newSeries.Episodes,
            IsCompleted = newSeries.IsCompleted,
            YearStarted = newSeries.YearStarted,
            YearEnded = newSeries.YearEnded
        };
        await seriesRepository.CreateAsync(series);
        return Created($"api/Series/{newSeries.Id}", newSeries);
    }

    // PUT api/<SeriesController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] SeriesDTO updatedSeries)
    {
        var existingSeries = await seriesRepository.GetAsync(id);
        if (existingSeries is null)
        {
            return BadRequest(ErrorMessages.IdNotFound("series"));
        }
        existingSeries.Title = updatedSeries.Title;
        existingSeries.Seasons = updatedSeries.Seasons;
        existingSeries.Episodes = updatedSeries.Episodes;
        existingSeries.IsCompleted = updatedSeries.IsCompleted;
        existingSeries.YearEnded = updatedSeries.YearEnded;
        await seriesRepository.UpdateAsync(existingSeries);
        return Ok(updatedSeries);
    }

    [HttpPut("{id}/Genres/")]
    public async Task<IActionResult> Put(Guid id, [FromBody] AddGenreDTO addGenre)
    {
        var existingSeries = await seriesRepository.GetAsync(id);
        var existingGenre = await genresRepository.GetAsync(addGenre.GenreId);
        if (existingSeries is null || existingGenre is null)
        {
            return BadRequest(ErrorMessages.IdNotFound("series / genre"));
        }
        existingSeries.Genre = existingGenre;
        await seriesRepository.UpdateAsync(existingSeries);
        return Ok(existingSeries);
    }

    [HttpPut("{id}/Studios/")]
    public async Task<IActionResult> Put(Guid id, [FromBody] AddStudioDTO addStudio)
    {
        var existingSeries = await seriesRepository.GetAsync(id);
        var existingStudio = await studiosRepository.GetAsync(addStudio.StudioId);
        if (existingStudio is null || existingSeries is null)
        {
            return BadRequest(ErrorMessages.IdNotFound("series / studio"));
        }
        existingSeries.Studio = existingStudio;
        await seriesRepository.UpdateAsync(existingSeries);
        return Ok(existingSeries);
    }

    // DELETE api/<SeriesController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var existingSeries = await seriesRepository.GetAsync(id);
        if (existingSeries is null)
        {
            return BadRequest(ErrorMessages.IdNotFound("series"));
        }
        await seriesRepository.DeleteAsync(id);
        return NoContent();
    }
}
