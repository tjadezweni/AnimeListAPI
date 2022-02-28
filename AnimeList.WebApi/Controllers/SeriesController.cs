using AnimeList.Application.Serieses;
using AnimeList.Application.Serieses.Commands;
using AnimeList.Application.Serieses.Queries;
using AnimeList.Domain.Common;
using AnimeList.Domain.Serieses;
using AnimeList.WebApi.Controllers.Base;
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
        var query = new GetSeriesByIdQuery(id);
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
    public async Task<IActionResult> Post([FromBody] CreateSeriesCommand request)
    {
        var newSeries = await _mediator.Send(request);
        return Created("GetById", newSeries);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Series), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateSeriesCommand request)
    {
        request.Id = id;
        var updatedSeries = await _mediator.Send(request);
        return Ok(updatedSeries);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    public async Task<IActionResult> Delete(int id)
    {
        var query = new DeleteSeriesCommand(id);
        _ = await _mediator.Send(query);
        return NoContent();
    }
}
