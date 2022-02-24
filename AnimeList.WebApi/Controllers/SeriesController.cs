using AnimeList.Application.Serieses;
using AnimeList.Domain.Common;
using AnimeList.Domain.Serieses;
using AnimeList.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;


namespace AnimeList.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SeriesController : ControllerBase
{
    private readonly ISeriesService seriesService;

    public SeriesController(ISeriesService seriesService)
    { 
        this.seriesService = seriesService;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Series), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var series = await seriesService.GetById(id);
        return Ok(series);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Series>), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get()
    {
        var seriesList = await seriesService.Get();
        return Ok(seriesList);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Series), 201)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] Series newSeries)
    {
        await seriesService.Create(newSeries);
        return Created("", newSeries);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Series), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] Series updatedSeries)
    {
        updatedSeries.Id = id;
        updatedSeries = await seriesService.Update(updatedSeries);
        return Ok(updatedSeries);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    public async Task<IActionResult> Delete(int id)
    {
        await seriesService.Delete(id);
        return NoContent();
    }
}
