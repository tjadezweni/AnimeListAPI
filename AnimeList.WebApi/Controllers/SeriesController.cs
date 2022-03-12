using AnimeListAPI.Application.Commands.CreateSeries;
using AnimeListAPI.Application.Commands.DeleteSeries;
using AnimeListAPI.Application.Commands.UpdateSeries;
using AnimeListAPI.Application.Queries.GetAllSeriesQuery;
using AnimeListAPI.Application.Queries.GetSeriesById;
using AnimeListAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace AnimeList.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SeriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public SeriesController(IMediator mediator)
    { 
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Series), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetSeriesByIdQuery()
        {
            Id = id
        };
        var series = await _mediator.Send(query);
        return series is null ? NotFound() : Ok(series);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Series>), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllSeriesQuery();
        var seriesList = await _mediator.Send(query);
        return Ok(seriesList);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Series), 201)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] Series series)
    {
        var command = new CreateSeriesCommand()
        {
            Series = series
        };
        var newSeries = await _mediator.Send(command);
        return Created("GetById", newSeries);
    }

    [HttpPut]
    [ProducesResponseType(typeof(Series), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update([FromBody] Series series)
    {
        var command = new UpdateSeriesCommand()
        {
            Series = series
        };
        var updatedSeries = await _mediator.Send(command);
        return Ok(updatedSeries);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    public async Task<IActionResult> Delete(int id)
    {
        var query = new DeleteSeriesCommand()
        {
            Id = id
        };
        _ = await _mediator.Send(query);
        return NoContent();
    }
}
