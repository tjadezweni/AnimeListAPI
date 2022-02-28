using AnimeList.Application.Countries;
using AnimeList.Application.Countries.Commands;
using AnimeList.Application.Countries.Queries;
using AnimeList.Domain.Countries;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace AnimeList.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CountriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(Country), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get()
    {
        var query = new GetAllCountriesQuery();
        var countries = await _mediator.Send(query);
        return Ok(countries);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(List<Country>), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetCountryByIdQuery(id);
        var country = await _mediator.Send(query);
        return country is null ? NotFound() : Ok(country);
    }

    [HttpPost("")]
    [ProducesResponseType(typeof(Country), 201)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] CreateCountryCommand request)
    {
          
        var newCountry = await _mediator.Send(request);
        return Created("GetById", newCountry);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Country), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCountryCommand request)
    {
        request.Id = id;
        var updatedCountry = await _mediator.Send(request);
        return Ok(updatedCountry);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    public async Task<IActionResult> Delete(int id)
    {
        var query = new DeleteCountryCommand(id);
        _ = await _mediator.Send(query);
        return NoContent();
    }
}

public class AddCountryDTO
{
    public int Id { get; set; }
}
